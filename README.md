# Bulk File Creator
A simple and easy to use tool for creating multiple files with a single button click. This application is currently in development and will gradually have more features added, along with further optimizations in the near future. I had originally created this tool for the Unity game engine to generate C# scripts but felt that it could also be useful as a standalone application that can be used for any file type. 

The idea first came to me when thinking about Object Oriented design in programming. Developers that have this mindset when writing software sometimes tend to plan ahead when it comes to designing classes and figuring out what files they are going to need through multiple levels of inheritence. This tool will allow developers to quickly list out the names of each file that needs to be created and generate them with a single click.

#Standalone Version
# Future Plans
1. File templates - The user will have the opportunity to create default text and store it in templates that can be assigned to files whenever they are created. This will help developers fill each new file with the appropriate boilerplate code depending on the language or type of file.

2. Larger Batch Size - Raise the number of files allowed per batch from 10 to something much larger. This limit is not due to any technical restrictions, but I felt that 10 was a good enough number to start with for an initial version and more textboxes can be generated at a later time while utilizing a scrollbar
or pages.

3. Conversion to C++ - The tool is currently written with Windows Presentation Forms in C# and I want to port it over to C++ for possible optimizations and utilize a much smaller library for developing the graphical user interface.

4. Additional Platforms - The initial version is specifically built for Windows and will not work on other operating systems. I wanted to reduce the number of additional dependencies in the project and so I have not added in any third party libraries or files that would allow for me to build a cross platform version of the application. This means that I will need to write versions of the tool specifically for Linux and MacOS.

#Unity Version Differences
1. Boilerplate code included for .cs files.
2. Interface checkbox option for interface boilerplate instead.
