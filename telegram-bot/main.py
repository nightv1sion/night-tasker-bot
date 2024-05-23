import os

import telebot
from keys import KeyConstants
from settings.telegram_bot_settings import TelegramBotSettings
from workflows.add_challenge_workflow import AddChallengeWorkflow

from workflows.get_challenges_workflow import GetChallengesWorkflow


class Bot:
    instance = telebot.TeleBot(TelegramBotSettings.token)


@Bot.instance.message_handler(content_types=['text'])
def get_text_messages(message):
    if message.text == '/start':
        keyboard = telebot.types.InlineKeyboardMarkup()
        key_add_challenge = telebot.types.InlineKeyboardButton(
            text=KeyConstants.Challenge.Add.label,
            callback_data=KeyConstants.Challenge.Add.key)
        keyboard.add(key_add_challenge)
        Bot.instance.send_message(message.from_user.id, text='Выберите действие', reply_markup=keyboard)
    elif message.text == "/get_challenges":
        get_challenges(message)


@Bot.instance.callback_query_handler(func=lambda call: True)
def keyboard_callback(call: telebot.types.CallbackQuery):
    if call.data == KeyConstants.Challenge.Add.key:
        add_challenge(call.message)


def add_challenge(message: telebot.types.Message):
    workflow = AddChallengeWorkflow(Bot.instance, message.chat.id)
    workflow.start()


def get_challenges(message: telebot.types.Message):
    workflow = GetChallengesWorkflow(Bot.instance, message.chat.id)
    workflow.start()


Bot.instance.polling(none_stop=True, interval=0)
