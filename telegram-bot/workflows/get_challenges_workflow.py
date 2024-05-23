import telebot

from apis.task_tracker_api import TaskTrackerApi
from services.challenge_presenter import ChallengePresenter


class GetChallengesWorkflow:
    bot_instance: telebot.TeleBot
    user_id: int

    def __init__(self, bot_instance: telebot.TeleBot, user_id: int):
        self.bot_instance = bot_instance
        self.user_id = user_id

    def start(self):
        text = self.get_format_records()
        self.bot_instance.send_message(chat_id=self.user_id, text=text)

    def get_format_records(self):
        challenges = self.get_records()
        presenter = ChallengePresenter()
        return presenter.format_challenges(challenges)

    def get_records(self):
        task_tracker_api = TaskTrackerApi()
        return task_tracker_api.get_user_challenges(self.user_id)
