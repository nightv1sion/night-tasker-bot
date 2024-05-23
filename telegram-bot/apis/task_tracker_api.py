import array
import json
import os

import requests

from models.challenge_dto import ChallengeDto
from models.create_challenge_dto import CreateChallengeDto
from settings.api_settings import ApiSettings


class TaskTrackerApi:
    path = f'{ApiSettings.path}/challenges'

    def get_user_challenges(self, user_id: int):
        response = requests.get(f'{self.path}?userId={user_id}')
        responseJson: array.array[json] = response.json()
        challenges = map(lambda x: ChallengeDto.from_json(x), responseJson)
        return challenges

    def create_challenge(self, challenge: CreateChallengeDto):
        response = requests.post(f'{self.path}', json={
            'name': challenge.name,
            'description': challenge.description,
            'userId': challenge.user_id
        })
        challenge_id: str = response.json()
        return challenge_id
