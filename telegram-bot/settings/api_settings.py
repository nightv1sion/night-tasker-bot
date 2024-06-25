import os

from dotenv import load_dotenv

load_dotenv()


class ApiSettings:
    path: str = os.getenv('API_PATH')
