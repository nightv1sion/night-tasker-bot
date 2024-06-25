class AddChallengeMessageDto:
    message_id: int
    challenge_id: str

    def __init__(self, message_id: int, challenge_id: str):
        self.message_id = message_id
        self.challenge_id = challenge_id
