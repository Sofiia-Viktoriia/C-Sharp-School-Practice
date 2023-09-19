Feature: Practice of using form elements
	As a user of the ToolsQA website
	I want to be able to interact with different form elements in the Forms category
	So I can understand how they work

Background:
	Given user opens the 'Forms' category

Scenario: Filling and submitting the form
	Given user opens the 'Practice Form' section
	When user fills the form with values
		| FirstName | LastName | Email             | Gender | MobilePhone | DateOfBirth     | Subjects       | Hobbies        | CurrentAddress | State         | City   |
		| Alex      | Because  | alexwhy@gmail.com | Female | 1234567890  | 20 January 2005 | Physics; Maths | Reading; Music | Ukraine, Kyiv  | Uttar Pradesh | Merrut |
	And user submits the form
	Then modal page with entered values is displayed
