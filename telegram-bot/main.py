import telebot
from keys import KeyConstants
from settings.telegram_bot_settings import TelegramBotSettings
from workflows.challenges.add_challenge_workflow import AddChallengeWorkflow

from workflows.challenges.get_challenges_workflow import GetChallengesWorkflow
from workflows.challenges.update_challenge_workflow import UpdateChallengeWorkflow
from workflows.start.start_workflow import StartWorkflow


class Bot:
    instance = telebot.TeleBot(TelegramBotSettings.token)


@Bot.instance.message_handler(content_types=['text'])
def get_text_messages(message: telebot.types.Message):
    try:
        if message.text == '/start':
            start(message)
        elif message.text == "/get_challenges":
            get_challenges(message)
        elif message.text == '/add_challenge':
            add_challenge(message)
        elif message.text == '/edit_challenge':
            update_challenge(message)

    except Exception as e:
        Bot.instance.send_message(message.chat.id, text="Что-то пошло не так")


def start(message: telebot.types.Message):
    workflows = StartWorkflow(Bot.instance, message.chat.id)
    workflows.start()


def add_challenge(message: telebot.types.Message):
    workflow = AddChallengeWorkflow(Bot.instance, message.chat.id)
    workflow.start()


def get_challenges(message: telebot.types.Message):
    workflow = GetChallengesWorkflow(Bot.instance, message.chat.id)
    workflow.start()

def update_challenge(message: telebot.types.Message):
    replied_message_id = message.reply_to_message.message_id
    if(replied_message_id is None):
        Bot.instance.send_message(message.chat.id, text="Задача должна быть переслана")
    workflow = UpdateChallengeWorkflow(Bot.instance, message.chat.id, replied_message_id)
    workflow.start()

Bot.instance.polling(none_stop=True, interval=0)
