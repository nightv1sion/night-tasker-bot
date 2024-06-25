import os

from dotenv import load_dotenv

load_dotenv()


class TelegramBotSettings:
    token = os.getenv("TELEGRAM_BOT_TOKEN")
