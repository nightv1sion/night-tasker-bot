import telebot

from apis.task_tracker.task_tracker_api import TaskTrackerApi
from models.challenges.update_challenge_dto import UpdateChallengeDto


class UpdateChallengeWorkflow:
    ask_challenge_name_text: str = 'Введите новое название задачи:'
    ask_challenge_description_text: str = 'Введите новое описание задачи:'

    bot_instance: telebot.TeleBot
    user_id: int
    challenge_message_id: int
    challenge: UpdateChallengeDto

    task_tracker_api: TaskTrackerApi

    def __init__(self, bot_instance: telebot.TeleBot, user_id: int, challenge_message_id: int):
        self.bot_instance = bot_instance
        self.user_id = user_id
        self.challenge_message_id = challenge_message_id
        self.task_tracker_api = TaskTrackerApi()
        challenge_dto = self.task_tracker_api.get_challenge_by_message_id(self.challenge_message_id, self.user_id)
        self.challenge = UpdateChallengeDto(challenge_dto.id, challenge_dto.name, challenge_dto.description)

    def start(self):
        self.ask_fields()

    def ask_fields(self):
        self.ask_name()

    def ask_name(self):
        keyboard = telebot.types.InlineKeyboardMarkup(row_width=1)
        cancel_button = telebot.types.
        keyboard.add(cancel_button)
        message = self.bot_instance.send_message(
            chat_id=self.user_id,
            text=self.ask_challenge_name_text,
            reply_markup=keyboard)
        self.bot_instance.register_next_step_handler(message=message, callback=self.get_name)

    def get_name(self, message: telebot.types.Message):
        if(message.text != 'Оставить'):
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
        task_tracker_api.edit_challenge(self.challenge)
        self.bot_instance.send_message(self.user_id, text=f'Задача отредактирована')