# TimeConstComp
Simple code sample that demos constant-time string compare. 

Comparing passwords is subject to timing attacks, this code will take two strings, hash 'em and then compare the two hashes, which are the same length. 
The 'comparison' is actually a running bitwise-OR of a byte-by-byte XOR.
