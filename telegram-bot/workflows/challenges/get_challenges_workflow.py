import telebot

from apis.task_tracker.requests.add_challenge_messages_request import AddChallengeMessagesRequest
from apis.task_tracker.task_tracker_api import TaskTrackerApi
from models.challenge_messages.add_challenge_message_dto import AddChallengeMessageDto
from models.challenges.challenge_dto import ChallengeDto
from services.challenge_presenter import ChallengePresenter


class GetChallengesWorkflow:
    bot_instance: telebot.TeleBot
    user_id: int
    challenge_presenter: ChallengePresenter
    task_tracker_api: TaskTrackerApi

    def __init__(self, bot_instance: telebot.TeleBot, user_id: int):
        self.bot_instance = bot_instance
        self.user_id = user_id
        self.challenge_presenter = ChallengePresenter()
        self.task_tracker_api = TaskTrackerApi()

    def start(self):
        challenges: list[ChallengeDto] = self.get_challenges()
        if len(challenges) == 0:
            self.bot_instance.send_message(self.user_id, text='Задач нет')
            return

        challenge_messages: list[AddChallengeMessageDto] = list([])
        for challenge in challenges:
            formatted_challenge = self.format_challenge(challenge)
            message = self.bot_instance.send_message(self.user_id, text=formatted_challenge)
            dto = AddChallengeMessageDto(message_id=message.message_id, challenge_id=challenge.id)
            challenge_messages.append(dto)

        add_challenge_messages_request = AddChallengeMessagesRequest(challenge_messages, self.user_id)
        self.task_tracker_api.add_challenge_messages(add_challenge_messages_request)

    def get_format_records(self):
        challenges = self.get_challenges()
        presenter = ChallengePresenter()
        return presenter.format_challenges(challenges)

    def get_challenges(self):
        task_tracker_api = TaskTrackerApi()
        return task_tracker_api.get_user_challenges(self.user_id)

    def format_challenge(self, challenge):
        return self.challenge_presenter.format_challenge(challenge)
