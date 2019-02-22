# TimeConstComp
Simple code sample that demos constant-time string compare. 

Comparing passwords is subject to timing attacks, this code will take two strings, hash 'em and then compare the two hashes, which are the same length. 
The 'comparison' is actually a running bitwise-OR of a byte-by-byte XOR.

https://michaelhowardsecure.blog/2019/02/22/the-dangers-of-string-comparing-passwords/ for more info
