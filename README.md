# Good-Match
### Scenario
A local tennis club has decided to organise a tournament open to the general public as a way to promote tennis and the club itself. They have advertised widely and received many responses from people that are interested. As with any major tennis tournament there will be a mixed doubles event. Partners will be allocated according to an algorithm they have devised and you have been approached to write the program.

### Problem
Calculate the match percentage between two peoples first names.
The sentence to be processed will read as {name1} matches {name2}, for example 'Jack matches Jill' 
- Starting from the left, read the first character in the sentence and count how many times that character occurs.
- Move on to the next character that has not been counted yet
- Repeat until all characters in the sentence have been counted
- You should now have a number showing how many times each character occurred in the sentence
This number now needs to be reduced to a 2 digit number.
- Add the left most and right most number that has not been added yet and put its sum at the end of the result.
- If there is only one number left add that number to the end of the result
- Repeat this process until there are only 2 digits left in the final string
