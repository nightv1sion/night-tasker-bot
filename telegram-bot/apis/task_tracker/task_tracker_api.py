import array
import json

import requests
from apis.task_tracker.requests.add_challenge_messages_request import AddChallengeMessagesRequest

from models.challenges.challenge_dto import ChallengeDto
from models.challenges.create_challenge_dto import CreateChallengeDto
from models.challenges.update_challenge_dto import UpdateChallengeDto
from settings.api_settings import ApiSettings


class TaskTrackerApi:
    path = f'{ApiSettings.path}'

    def get_user_challenges(self, user_id: int):
        response = requests.get(f'{self.path}/challenges?userId={user_id}')
        responseJson: array.array[json] = response.json()
        challenges = map(lambda x: ChallengeDto.from_json(x), responseJson)
        return list(challenges)

    def get_challenge_by_message_id(self, message_id:int, user_id: int):
        response = requests.get(f'{self.path}/challenge-messages/{message_id}?userId={user_id}')
        challenge: ChallengeDto = ChallengeDto.from_json(response.json())
        return challenge

    def create_challenge(self, challenge: CreateChallengeDto):
        response = requests.post(f'{self.path}/challenges', json={
            'name': challenge.name,
            'description': challenge.description,
            'userId': challenge.user_id
        })
        challenge_id: str = response.json()
        return challenge_id

    def edit_challenge(self, challenge: UpdateChallengeDto):
        requests.put(f'{self.path}/challenges/{challenge.id}', json={
            'name': challenge.name,
            'description': challenge.description,
        })

    def add_challenge_messages(self, challengeMessages: AddChallengeMessagesRequest):
        body = {
            'challengeMessages': [{'messageId': x.message_id, 'challengeId': x.challenge_id}
                                  for x in challengeMessages.challenge_messages],
            'userId': challengeMessages.user_id
        }
        requests.post(f'{self.path}/challenge-messages', json=body)
