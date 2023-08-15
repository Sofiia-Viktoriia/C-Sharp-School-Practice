Feature: Practice of using the HTML elements
	As a user of the ToolsQA website
	I want to be able to interact with different HTML elements in the Elements category
	So I can understand how they work

Background:
	Given user opens the 'Elements' category
	And user is on the 'Elements' category page

Scenario: Submitting correct fields` values in Text Box section
	Given user opens the 'Text Box' section
	When user enters valid values in the text boxes
	| FullName  | Email             | CurrentAddress | PermanentAddress |
	| Alex Ones | email@address.com | USA, New York  | Ukraine, Kyiv    |
	And user clicks on Submit button
	Then the table should contain entered values
	| FullName  | Email             | CurrentAddress | PermanentAddress |
	| Alex Ones | email@address.com | USA, New York  | Ukraine, Kyiv    |

Scenario: Selecting elements in Check Box section
	Given user opens the 'Check Box' section
	When user opens the 'Home' element
	And user selects the 'Desktop' element
	And user opens the 'Documents' element
	And user opens the 'WorkSpace' element
	And user selects the 'Angular' element
	And user selects the 'Veu' element
	And user opens the 'Office' element
	And user selects all elements in the 'Office' folder
	And user opens the 'Downloads' element
	And user selects the 'Downloads' element
	Then the selection result should be equal 'You have selected : desktop notes commands angular veu office public private classified general downloads wordFile excelFile'

Scenario: Sorting column values in the table in Web Tables section
	Given user opens the 'Web Tables' section
	When user clicks on the 'Salary' column name
	Then the values in the 'Salary' numeric column should be sorted ascending

Scenario: Deleting the row in the table in Web Tables section
	Given user opens the 'Web Tables' section
	And the amount of rows equals 3
	When user deletes the row with the 'Name' value equals 'Alden'
	Then the amount of rows should be equal 2
	And the row with the 'Department' value equals 'Compliance' should not exist

Scenario Outline: Clicking on the button in Buttons section
	Given user opens the 'Buttons' section
	When user interacts with the '<buttonName>' button
	Then the result '<actionMessage>' should be displayed

Examples: 
	| buttonName      | actionMessage                 |
	| Double Click Me | You have done a double click  |
	| Right Click Me  | You have done a right click   |
	| Click Me        | You have done a dynamic click |
