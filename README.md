# Leap-Frog
# Commit one notes
I edited the character controller to have a seperate script for each character. These scripts reference a point script that corresponds to the character the controller script is attached to. 
To ensure that only the leaper gets the point and not the player leapt over I only allowed the jumping character (detected via keypress and boolean isJumping) to have their points variable increased in the UI. I also used and EInumerator variable to ensure that a character could only gain one point per leap (this added a time delay). 
I also added a clear UI display early on to make the scores/winner visible to the player. This along with additional objects (some that take away points from characters upon contact "these ones are red") upped the skill level players would need with their controls to gain points. 
