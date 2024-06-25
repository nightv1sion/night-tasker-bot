class UpdateChallengeDto:
    id: int
    name: str
    description: str

    def __init__(self, id: int, name: str, description: str):
        self.id = id
        self.name = name
        self.description = description

    def get_name(self):
        return self.name

    def set_name(self, name: str):
        self.name = name

    def get_description(self):
        return self.description

    def set_description(self, description: str):
        self.description = description