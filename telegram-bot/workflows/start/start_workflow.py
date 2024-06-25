import telebot

from keys import KeyConstants


class StartWorkflow:
    bot_instance: telebot.TeleBot
    user_id: int

    def __init__(self, bot_instance: telebot.TeleBot, user_id: int):
        self.bot_instance = bot_instance
        self.user_id = user_id

    def start(self):
        keyboard = telebot.types.InlineKeyboardMarkup()
        key_add_challenge = telebot.types.InlineKeyboardButton(
            text=KeyConstants.Challenge.Add.label,
            callback_data=KeyConstants.Challenge.Add.key)
        keyboard.add(key_add_challenge)
        self.bot_instance.send_message(self.user_id, text='Выберите действие', reply_markup=keyboard)
