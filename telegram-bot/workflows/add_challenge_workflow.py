import telebot

from apis.task_tracker_api import TaskTrackerApi
from models.create_challenge_dto import CreateChallengeDto


class AddChallengeWorkflow:
    ask_challenge_name_text: str = 'Введите название задачи:'
    ask_challenge_description_text: str = 'Введите описание задачи:'
    challenge: CreateChallengeDto

    bot_instance: telebot.TeleBot
    user_id: int

    def __init__(self, bot_instance: telebot.TeleBot, user_id: int):
        self.bot_instance = bot_instance
        self.user_id = user_id
        self.challenge = CreateChallengeDto(user_id)

    def start(self):
        self.ask_name()

    def ask_name(self):
        message = self.bot_instance.send_message(chat_id=self.user_id, text=self.ask_challenge_name_text)
        self.bot_instance.register_next_step_handler(message=message, callback=self.get_name)

    def get_name(self, message: telebot.types.Message):
        self.challenge.set_name(message.text)
        self.ask_description()

    def ask_description(self):
        message = self.bot_instance.send_message(chat_id=self.user_id, text=self.ask_challenge_description_text)
        self.bot_instance.register_next_step_handler(message=message, callback=self.get_description)

    def get_description(self, message: telebot.types.Message):
        self.challenge.set_description(message.text)
        self.save_challenge()

    def save_challenge(self):
        task_tracker_api = TaskTrackerApi()
        task_tracker_api.create_challenge(self.challenge)
        self.bot_instance.send_message(self.user_id, text=f'Задача "{self.challenge.name}" создана')
