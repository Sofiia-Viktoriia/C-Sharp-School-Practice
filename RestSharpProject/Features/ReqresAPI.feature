Feature: ReqresAPI
	As a user of reqres.in web site
	I want to be able to send requests
	To understand the requests work

@Reqres
Scenario: Getting list of users
	When I send request to get list of users
	Then response code equals 200
	And response body contains list of users

@Reqres
Scenario: Getting user that don't exist
	Given user has id 100
	When I send request to get a single user
	Then response code equals 404

@Reqres
Scenario Outline: Getting existing user
	Given user has id <IdValue>
	When I send request to get a single user
	Then response code equals 200
	And response body contains user with id <IdValue>

Examples: 
	| IdValue |
	| 2       |
	| 3       |
	| 10      |

@Reqres
Scenario: Creating new user
	Given user has the following data
		| Name | Job     |
		| Alex | Teacher |
	When I send request to create a user
	Then response code equals 201
	And response body contains the entered user data

@Reqres
Scenario: PUT updating a user
	Given user has id 2
	And data for updating user includes
		| Name | Job |
		| Zeus | God |
	When I send PUT request to update a user
	Then response code equals 200
	And response body contains the entered user data

@Reqres
Scenario: PATCH updating a user
	Given user has id 2
	And data for updating user includes
		| Name      | Job     |
		| Aphrodite | Goddess |
	When I send PATCH request to update a user
	Then response code equals 200
	And response body contains the entered user data

@Reqres
Scenario: Deleting a user
	Given user has id 2
	When I send request to delete a user
	Then response code equals 204

@Reqres
Scenario: Successful registration
	Given user has the following registration data
		| Email              | Password |
		| eve.holt@reqres.in | pistol   |
	When I send request to register
	Then response code equals 200

@Reqres
Scenario: Successful login
	Given user has the following login data
		| Email              | Password   |
		| eve.holt@reqres.in | cityslicka |
	When I send request to login
	Then response code equals 200

@Reqres
Scenario: Getting list of users with delay
	Given delay equals 3 seconds
	When I send request to get list of users with delay
	Then response code equals 200
	And response body contains list of users