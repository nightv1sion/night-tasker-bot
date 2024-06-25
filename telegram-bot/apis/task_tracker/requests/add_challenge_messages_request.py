from models.challenge_messages.add_challenge_message_dto import AddChallengeMessageDto


class AddChallengeMessagesRequest:
    challenge_messages: list[AddChallengeMessageDto]
    user_id: int

    def __init__(self, challenge_messages: list[AddChallengeMessageDto], user_id: int):
        self.challenge_messages = challenge_messages
        self.user_id = user_id
