class ChallengeDto:
    id: int
    name: str
    description: str
    user_id: int

    def __init__(self, id: int, name: str, description: str, user_id: int):
        self.id = id
        self.name = name
        self.description = description
        self.user_id = user_id
        
    def from_json(json):
        return ChallengeDto(json['id'], json['name'], json['description'], json['userId'])
