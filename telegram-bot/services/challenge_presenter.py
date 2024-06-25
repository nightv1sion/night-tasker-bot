import array

from models.challenges.challenge_dto import ChallengeDto


class ChallengePresenter:

    def format_challenges(self, challenges: array.array[ChallengeDto]):
        return list(map(self.format_challenge, challenges))

    def format_challenge(self, challenge: ChallengeDto):
        return f'ID: {challenge.id}\nНазвание: {challenge.name}\nОписание: {challenge.description}'
