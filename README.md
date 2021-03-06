# StudentRegistrationAPI
StudentRegistrationAPI is a ASP.NET Web Application using [.NET FRAMEWORK (4.8 Recommended)](https://dotnet.microsoft.com/download/dotnet-framework) that allows Students (ApplicationUser) to register for classes giving the user the options to choose from different courses, teachers, and departments.

#### Sample Look - Class Details
![image](https://user-images.githubusercontent.com/55348036/110220047-16095480-7e91-11eb-8652-bc696b3dd44e.png)

## Solution Layer

    1. Data This is where we setup our database using Entity Framework
         i. Class
         ii. Course
         iii. Department
         iv. Teacher
   
    2. Models The messenger that helps the data and presentation tiers communicate. Examples of services include authentication and authorization
         a. Create
         b. Detail
         c. Edit
         d. ListItems
    3. Services View Models represent the data that we want to show on the page. They are useful because you can pull specific properties from multiple tables
  
    4. API file This is the API part of our application. You might also see this referred to as the presentation tier.
   

## Directions for running the app locally

    ### registering
    1. Run the application, and it should open your browser.(if not make sure webAPI is startup project )
    2. Copy the URL https://localhost:44318/:
    3. Open Postman and find your way to the Postman window:
    4. Paste the URL into the address bar and make sure the HTTP drop-down is set to POST
    5. If we check our API documentation, under Account we should see a Register endpoint.
    6. We'll now register via that endpoint.
    7. https://localhost:44318/api/Account/RegisterLinks to an external site.
    8. Keys and values required 
|   	| Key             	| Value    	| Type   	|
|---	|-----------------	|----------	|--------	|
| 1 	| Email            	| Required 	| string 	|
| 2 	| Password        	| Req      	| str    	|
| 3 	| ConfirmPassword 	| Req      	| str    	|
| 4 	| First           	| Req      	| str    	|
| 5 	| Last            	| Req      	| str    	|
| 6 	| Year            	| Non      	| str    	|
| 7 	| Major           	| Non      	| str    	|


 ### Posting 
    1. Run the API project
    2. Open Postman
    3. Click on the + to create a new request

### Required Key and value 

#### 1. Teacher
        
| Name      	| Type    	| information 	            |
|-----------	|---------	|------------------------	|
| FirstName 	| string  	| Required               	|
| LastName  	| string  	| Required               	|
| CourseId  	| integer 	| None.                  	|
        
#### 2. Course
| Name  	| Type   	| information                 	            |
|-------	|--------	|----------------------------------------	|
| Title 	| string 	| Required Max length: 100 Min length: 2 	|
|       	|        	|                                        	|
|       	|        	|                                        	|
#### 3. Class
| Name         	| Type    	| information                             	|
|--------------	|---------	|----------------------------------------	|
| Name         	| string  	| Required Max length: 100 Min length: 2 	|
| CourseId     	| integer 	| Required                               	|
| TeacherId    	| integer 	| Required                               	|
| StudentId    	| string  	| Required                               	|
| DepartmentId 	| integer 	| Required                               	|        
#### 4. Department
| Name         	| Type    	| information 	|
|--------------	|---------	|-------------	|
| DepartmentID 	| integer 	| Required    	|
| Name         	| string  	| Required    	|
| Building     	| string  	| Required    	|
