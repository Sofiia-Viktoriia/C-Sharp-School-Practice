Feature: MathjsAPI
	As a user of mathjs.org web site
	I want to be able to send requests
	To understand the requests work

@PostRequest
Scenario Outline: Addition of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| 1 + 2      | 3      |
	| 5 + 3      | 8      |
	| 234 + 294  | 528    |

@PostRequest
Scenario Outline: Subtraction of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| 1 - 2      | -1     |
	| 15 - 3     | 12     |
	| 234 - 234  | 0      |

@PostRequest
Scenario Outline: Multiplication of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| 0 * 2      | 0      |
	| 15 * 3     | 45     |
	| 4 * -3     | -12    |

@PostRequest
Scenario Outline: Division of two numbers
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| 0 / 2      | 0      |
	| 15 / 3     | 5      |
	| 40 / -4    | -10    |

@GetRequest
Scenario Outline: Getting square of the number
	When I send a request to calculate '<Expression>'
	Then response contains the '<Result>'

Examples: 
	| Expression | Result |
	| sqrt(4)    | 2      |
	| sqrt(121)  | 11     |
	| sqrt(-49)  | 7i     |
