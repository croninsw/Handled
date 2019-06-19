# HANDLED

As a longtime bicycle commuter, experience has taught me that a defensive, “everyone is a bad driver” mentality is the key to a safe journey across town. This idea came to me after a couple close calls on the road, where I didn’t know what kind of information to collect from drivers or other cyclists. HANDLED provides a simple and easily accessible solution to that problem.

The Web App is built with Entity Framework using MVC and ADO.NET. I spent a good deal of time organizing and setting up the database using Microsoft SQL and Azure Data Studio. Entity allowed me to quickly scaffold my controllers and views from my base models, and Identity Framework helped give everything a userId.


## Getting Started
1. Clone repo using `git clone git@github.com:croninsw/Handled.git`
1. open Virtual Studio and run Handled
1. Create a new account and login

## Version 2.0 Goals
1. Given a user wants to locate the nearest bicycle repair shop
    When the user searches their address in a search bar
    Then all shops should be listed with their location, using Google Maps API

1. Given a user wants to alert their friends, families (Emergency Contacts)
    When a user clicks on an affordance title such
    Then an email / phone blast is sent out to their contacts
    Using Email.js

## As the final capstone in my time here at Nashville Software School,
I want to say thank you to all of my peers in Cohort 30. Thank you to the instructors: Steve Brownlee, Meg Ducharme, Jenna Solis and all of our T.A.'s.
