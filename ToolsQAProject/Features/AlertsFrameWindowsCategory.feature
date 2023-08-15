Feature: Practice of using alerts, frames, and windows
	As a user of the ToolsQA website
	I want to be able to interact with different elements in the Alerts, Frame & Windows category
	So I can understand how they work

Background:
	Given user opens the 'Alerts, Frame & Windows' category
	And user is on the 'Alerts, Frame & Windows' category page

Scenario Outline: Opening new tab/window
	Given user opens the 'Browser Windows' section
	When user clicks on '<ButtonName>' button
	Then a new tab/window opens with 'This is a sample page' text in it

Examples: 
	| ButtonName |
	| New Tab    |
	| New Window | 
