using Dapper;
using Planner.Common.Infrastructure.Abstractions;
using Planner.Plans.Domain.Plans.Entities;
using Planner.Plans.Domain.Plans.Repositories;
using Planner.Plans.Infrastructure.Configurations;

namespace Planner.Plans.Infrastructure.Repositories.Plans;

internal sealed class PlanReadRepository(IDbConnectionFactory dbConnectionFactory)
    : GenericReadRepository<Plan>(dbConnectionFactory), IPlanReadRepository
{
    public async Task<IReadOnlyCollection<Plan>> GetUserPlansAsync(int userId)
    {
        IEnumerable<Plan> plans = await _connection.QueryAsync<Plan, PlanReminder, Plan>(
            @$"SELECT * FROM {Schemas.Plans}.{PlanConfiguration.TableName} c
            LEFT JOIN {Schemas.Plans}.{PlanReminderConfiguration.TableName} cr on c.id = cr.plan_id
            WHERE c.user_id = @userId", (plan, reminder) =>
            {
                if (reminder is not null)
                {
                    plan.Reminders.Add(reminder);
                }
                
                return plan;
            } ,
            new { userId }
            );
        return plans.ToArray();
    }
}
