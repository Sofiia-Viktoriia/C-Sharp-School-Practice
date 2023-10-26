Feature: MathjsAPI
	As a user of mathjs.org web site
	I want to be able to send requests
	To understand the requests work

Scenario Outline: Addition of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression  | Result |
	| 1 + 21      | 22     |
	| 5.1 + 3.6   | 8.7    |
	| -234 + -294 | -528   |
	| -12 + 22    | 10     |
	| -1 + 1      | 0      |

Scenario Outline: Subtraction of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression   | Result |
	| 1 - 2        | -1     |
	| 15 - 3       | 12     |
	| 234 - 234    | 0      |
	| 12.3 - 11.24 | 1.06   |
	| -14 - 5      | -19    |

Scenario Outline: Multiplication of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| 0 * 2      | 0      |
	| 15 * 3     | 45     |
	| 4 * -3     | -12    |
	| -5 * -10   | 50     |
	| 3.5 * 3.1  | 10.85  |

Scenario Outline: Division of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result      |
	| 0 / 2      | 0           |
	| 2 / 0      | Infinity    |
	| 15 / 3     | 5           |
	| 40 / -4    | -10         |
	| -30 / -10  | 3           |
	| 12.5 / 3.3 | 3.787878788 |

Scenario Outline: Getting square of the number
	When I send a request to get a square root of a <Value>
	Then response contains the correct square root of a <Value> value

Examples: 
	| Value |
	| 121   |
	| -49   |
	| 10.3  |
	| 0     |
