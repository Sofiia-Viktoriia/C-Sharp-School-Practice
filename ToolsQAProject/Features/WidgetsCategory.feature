Feature: Practice of using widgets
	As a user of the ToolsQA website
	I want to be able to interact with different widgets in the Widgets category
	So I can understand how they work

Background:
	Given user opens the 'Widgets' category

Scenario: Entering a value into the auto completing field with multiple values in Auto Complete section
	Given user opens the 'Auto Complete' section
	When user enters 'g' value into the auto completing field with multiple values
	Then list with 3 suggestions appears
	And all suggestions contain 'g' value

Scenario: Deleting values from auto completing field with multiple values in Auto Complete section
	Given user opens the 'Auto Complete' section
	When user adds values to the auto completing field with multiple values
		| Values |
		| Red    |
		| Yellow |
		| Green  |
		| Blue   |
		| Purple |
	And user deletes values from the auto completing field with multiple values
		| Values |
		| Yellow |
		| Purple |
	Then the values are displayed in the auto completing field with multiple values
		| Values |
		| Red    |
		| Green  |
		| Blue   |

Scenario: Resetting the progress bar in Progress Bar section
	Given user opens the 'Progress Bar' section
	When user clicks 'Start' button
	Then progress bar value reaches '100%'
	And 'Reset' button is displayed
	When user clicks 'Reset' button
	Then 'Start' button is displayed
	And progress bar value equals to '0%'
