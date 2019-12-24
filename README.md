# Super Calculator multi-number systems 
 A Super Calculator with all mathematical operations in all number systems.
 
 I coded it with shunting-yard algorithm for the parentheses ( ) but I can't find that code
 
 

 
             * a number is taken , If it's an integer
             * then It's converted normally
             * If It's negative , then we remove the negative sign ,convert the number , then add the sign again
             * I'f It's fraction , then we split it into two integer part , convert each part Alone
             * then combine them
             * as the .Net Framework can't convert fractions between different bases
             * 
             * the conversion process is as follows 
             * from hex to binary
             * 1.the hex value is converted to decimal value
             * 2.the decimal value is converted to binary
             * for fractions complements are used
             * the following Algorithm (invented by me) B = A * r1^2/r2^n 
             * where B is the result , A is the number we want to convert , r1 is A's radix(base) , r2 is B's radix
             * the number is converted to decimal , 
             * then result = Number * Tobase ^n / It's Base ^n where n is the number of digits
             * parts are then combined
             

![GUI](https://raw.githubusercontent.com/MagicianMido32/Super-Calculator-multi-number-systems/master/2222.PNG)
