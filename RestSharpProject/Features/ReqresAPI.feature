Feature: ReqresAPI
	As a user of reqres.in web site
	I want to be able to send requests
	To understand the requests work

Scenario: Getting list of users
	When I send request to get list of users
	Then response body contains list of users

Scenario: Getting user that don't exist
	When I send request to get a single user with id 100
	Then user is not found

Scenario Outline: Getting existing user
	When I send request to get a single user with id <IdValue>
	Then response body contains user with id <IdValue>

Examples: 
	| IdValue |
	| 2       |
	| 3       |
	| 10      |

Scenario: Creating new user	
	When I send request to create a user with the following data
		| Name | Job     |
		| Alex | Teacher |
	Then user is created

Scenario: Full updating a user
	When I send a request to update a user with id 2 fully
		| Name | Job |
		| Zeus | God |
	Then user is updated

Scenario: Partial updating a user
	When I send a request to update a user with id 2 partially
		| Name      | Job     |
		| Aphrodite | Goddess |
	Then user is updated

Scenario: Deleting a user
	When I send request to delete a user with id 2
	Then user is deleted

Scenario: Successful registration
	When I send request to register with the following data
		| Email              | Password |
		| eve.holt@reqres.in | pistol   |
	Then user is registered

Scenario: Successful login	
	When I send request to login with the following credentials
		| Email              | Password   |
		| eve.holt@reqres.in | cityslicka |
	Then user is logged in

Scenario: Getting list of users with delay
	When I send request to get list of users with 3 seconds delay
	Then response body contains list of users