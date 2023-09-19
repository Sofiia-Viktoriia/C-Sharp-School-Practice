Feature: Practice of using the interactive elements
	As a user of the ToolsQA website
	I want to be able to use different interactive elements in the Interactions category
	So I can understand how they work

Background:
	Given user opens the 'Interactions' category

Scenario: Selecting squares in the grid
	Given user opens the 'Selectable' section
	When user switches to 'Grid' tab
	And user selects squares
		| Number |
		| 1      |
		| 3      |
		| 5      |
		| 7      |
		| 9      |
	Then selected squares contain values
		| Value |
		| One   |
		| Three |
		| Five  |
		| Seven |
		| Nine  |
