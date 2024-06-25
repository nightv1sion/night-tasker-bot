class CreateChallengeDto:
    user_id: int
    name: str
    description: str

    def __init__(self, user_id: int):
        self.user_id = user_id

    def get_name(self):
        return self.name

    def set_name(self, name: str):
        self.name = name

    def get_description(self):
        return self.description

    def set_description(self, description: str):
        self.description = description