from dataclasses import dataclass


@dataclass(frozen=True)
class KeyConstants:
    class Challenge:
        class Add:
            label = 'Добавить задачу'
            key = "AddChallenge"

        class ConfirmAdding:
            class Yes:
                label = "Да"
                key = "ConfirmAddingChallengeYes"

            class No:
                label = "Нет"
                key = "ConfirmAddingChallengeNo"
