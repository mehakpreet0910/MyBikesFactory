# MyBikesFactory

Description: 
This is a simple windows based application in C# which involves  a three-tier model i.e. use of class library and windows application form.The main part of the project is to make the functionality of windows form which is a user interface layer and other two are class libraries on which the windows form is  dependent.The application will involve use of concepts  like encapsulation, polymorphism, abstraction and inheritance.


Case Study:
 My BIKES FACTORY is a major Canadian producer of bikes and bike equipments located in Montreal.
A bike contains following information:
•	 Serial Number which is unique for each bike.
•	Name
•	Model
•	Color 
•	Manufacturing Year
It manufactures two types of bikes i.e. Mountain Bikes and Road Bikes.
Mountain Bike has Suspension as its specific feature.Further more suspension has three types:
•	Front
•	Rear
•	Dual
Road Bike has Tire as its specific feature.Moving further tire has three categories:
•	Regular
•	Commuter
•	Gravel
Information regarding tires can't be used for mountain bikes and suspension types information is not meant for road bikes.


Documentation:
The solution contains three layers with following namespaces:
•	Business Layer i.e. MyBikesFactory.Business
•	Data Layer i.e. MyBikesFactory.Data
•	User Interface Layer i.e MyBikesFactory.UI
Business Layer: This layer is a class library and we have added the items given below in this layer.
 

•	A folder named as enums i.e. enumerations.
•	Five classes named:
I.	Bike
II.	MountainBike
III.	RoadBike
IV.	User
V.	Validator
Enumerations: This folder further has 3 classes:
1.	EColor: This is a public enum which has name of colors available in bikes.
2.	ESuspensionType: This public enum conatins suspension types of mountain bikes.
3.	ETireType:This public enum contains tire types of road bikes.
Classes:
1.	Bike:It is a parent class and is abstract .The information from our enum folder is used in this class.The following fields are defined in this class.
a.	Serial Number: Declared as "int".
b.	Name: Declared as "string".
c.	Model: Declared as "string".
d.	Color: Using class EColor from enums folder.
e.	ManufacturingYear: Declared as "float"
      2.  MountainBike:It is a public child class of bike class and inherits all the information from  it.     Moreover, it contains suspension type field using details from class ESuspensionType in enums folder.
     3.  RoadBike:It is a public child class of bike class and inherits all the information from  it.     Moreover, it contains tire type field using details from class ETireType in enums folder.
    4.   User:It is a public class and contains two fields named as username and password.Both of   them are declared as string.
   5.   Validator:This class is used to validate the fields declared in bike class using regular expressions.
•	Serial Number:It is validated as an integer and should contain only numeric values.Moreover, it should be unique for every single bike.
•	Model:The model of the bike should contain combination of characters and numbers only.Further more, the model should have only five characters or numbers.
•	Manufacturing Year:The manufacturing year can contain only numbers and should be exactly four numbers.
Data Layer:This layer is dependent on business layer i.e.MyBikesFactory.Business. Moving on, it involves two class named as BikeXMLData and UserSequentialData and one class diagram.
 
Dependencies:
 



ClassDiagram:The class diagram links the mountain bike class and road bike class to the bike class which is parent class.The diagram depicts the relationship between the three classes.
 

BikeXMLData:This class involves the use of xml serialization system  and it creates a file named as "Bikes" with extension .xml  in which it saves  all the data entered in the windows form of bikes factory in UI layer.
 


UserSequentialData:This class is build in order to enter username and password in login form.The information is entered manually in the text file and then with help of the class the information is used in the login form in order to access the "MainForm" form.
 

User Interface Layer:This layer is dependent both on business and data layer.It contains two window forms named as "LoginForm" and "MainForm".
 
 


LoginForm:This form has following items:
 

A label named username and in front of it is a textbox that is to write the username.
Second label named as password and the textbox opposite it is to enter password whose characters are disabled.
Third item is a button named login to go to main form.
MainForm:This form is the main functionality of the whole application.The whole project involves around this form.It has the following items.
 
·	Eight labels named as Bike Type, Serial Number, Name, Model, Manufacturing Year, Color, Suspension Type and Tire Type.
·	Four combo boxes: 
i.	First one to select bike type i.e. Mountain or Road.    
ii.	Second box is for color.It contains four colors-Black, Blue, Green or Red 
iii.	Next one is suspension type-Front, Rear, Dual     
iv.	 Tire type is the last one-Regular, Commuter, Gravel
•	Four text boxes for entering serial number, name, model and manufacturig year.
•	Moving on is a label named original serial number and the text box opposite it is for showing the serial number of bike.
•	Next the form has two buttons named as Add and Update.
•	A label named "Display All Mountain or Road Bikes"
•	In front of the above mentioned label are three radio buttons-All, Mountain and Road
•	Further is a list box "lstBikes" to display all the information regarding bikes.
•	Lastly are four buttons - Remove, Search, Save and Exit in a series. 
Functionality:
LoginForm:Enter the username and password that you have written manually in the text file created manually.Then you click on login button and it takes you to the main form.
MainForm:Coming to the main form use have to enter the following information:
a.	Select a bike type from combo box
 

b.	Enter the serial number, name, model and manufacturing year according to the validations otherwise the information will not get added.Moreover an error message will be displayed if conditions are violated.

c.	Select the color from the given colors in combo box.
 

d.	Out of suspension type and tire type only one combo box will be enabled depending on the bike type you select.For instance if you select mountain as bike type then you will be allowed to select suspension type and tire type will be disabled and vice versa.
 
 


Then you click on the add button and the information gets added to the form and viewed in the list box.Moreover, if any one of the above mentioned boxes is empty the information will not get added and a message box will be displayed alerting you about the same.
 

The update button is used for updating the information of any existing bike in the list box except for the bike type.Bike type can't be changed once you add the information.Moreover you need to hover over the information of particular bike in order to update otherwise you cannot.
 
 


The original serial number box you see in the form is to display the serial number of bike so that while updating you don't repeat the same number.
 

Talking about the radio buttons, out of which, all is default. They display the information in the list box.
"All" radio button displays the information of both types of bike.
 

"Mountain" shows us the data of only mountain bike and same goes for the "Road".But you cannot remove information while you select these options.
 
 


The list box "lstBikes" is for displaying all the information after you click on the add or update button.
 

"Remove" button is used to remove data of any bike from the list .In this case you have to hover over the details to remove it.Otherwise the remove button doesn't work.
 
 


"Search" button search the bike through the serial number.You enter the serial number and if  a bike is identified  it displays a message box showing up all the information of bike otherwise the message "Bike not found" is displayed.
 
 


Moving further the "Save" button plays the main role in saving data in list box.If you don't press save button after adding or updating data, the details of bike will disappear on the next execution.Adding on the information will not appear in the xml file until we save it here in the form.
 
 


Lastly the "Exit" button is simply to exit the form.You click on it and a message box will ask you if you really want to exit.If you select yes the form will close otherwise you still remain on the form. 
 

Conclusion:This project taught to develop windows based application in C# in three tier model and applying the concepts of object oriented programming like abstraction,polymorphism etc.It taught to create classes and under them creating required fields and properties.Also building of constructors was part of this project and also learnt to create enumerations that were necessary for the classes.
The project also taught to save data as xml and text files.Creating a windows form and then  under it implementing different functionalities like add, search , remove etc.
Moreover, it taught to link two forms together i.e. how one form can be used to access the second one.
Overall, the main aim of the project was to learn how to make a form and implement different functionalities in it.it can be conclude that by doing this project the above case study can be implemented in real life.




