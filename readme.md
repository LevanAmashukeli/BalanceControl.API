# Balance Control

The project is written for the company and is ready to be checked out.
<br><br/>
#### Project published on Azure Server and ready to test: https://balancecontrolapi.azurewebsites.net/swagger
<br><br/>

# About Folder: "Additional Items"

Inserted in the "*Additional Items*" folder is a configured file called "*BalancemanagerTests.postman_collection.json*". It is needed for importing the file into *Postman* and after that, checking all the tests I have written.  
  
### Postman
 After importing the "*BalancemanagerTests.postman_collection.json*"  file into *Postman*, you will see "*API*" folder, which includes:
1. *ErrorCode* handler => "*Withdrawal*" and "*Deposit*" scenarios. Both methods have exception checking (*Transaction rejected* and *Not Enought Balance*). There are two methods in folders. All methods ready-made tests.
2. *Standard tests* - contains a folder and methods "*Balance (Balance check)*", "*Withdrawal*" and "*Deposit*". Using these methods, you can check the balance on your account, transfer money to the casino and vice versa, from the casino. All configured and are ready to work.

### Swagger
 *Swagger* is fully configured and ready to use. "*Summary*" and "*Descripton*" parameters passed to attributes for all three controllers
1. ***BalanceController*** => Summary: "*Check Balance*" => Description: "*Returns Casino balance*".
2. ***DepositController*** => Summary: "*Transfer money to Casino balance*" => Description: "*Transfer money from Game to Casino balance*".
3. ***WithdrawController*** => Summary: "*Transfer money to Game balance*" => Description: "*Transfer money from Casino to Game balance*";

# About Folder: "src"

**ASP.NET Core**: a **WEB API** project has been created, layers such as ***Application, Services, Shared*** have also been created separately in the *Class Library*.

 ***API*** - created "*Balance*", "*Withdraw*", "*Deposit*" controllers, "*App.config*" (it contains Key-Value taken from "*Enum ErrorCode*" ( "*ErrorCode*" description and Key )), *Startup* Life cycles , *Cors* and *Middleware* are fully configured and ready to work;

 - ***BalanceController*** - needed to check the balance of the *Casino*.
 - ***WithdrawController*** - Subtracts from the casino balance and adds money to the Game account by calling two methods (*IncreaseBalance* (*Game*) and *DecreaseBalance* (*Casino*)).
 - ***DepositController*** - Subtracts from the Game balance and adds money to the Casino account by calling two methods (IncreaseBalance(*Casino*) and DecreaseBalance(*Game*));
<br><br/>
 **Application** - i have written 3 services :
 - ***GetBalanceService*** -the controller works with the help of  *IGetBalanceService* interface. is created for the   "*CasinoBalanceManager*" check . (because of the 2 different interface was not implemented  in  "*BalanceManager.DLL*" ,i had to create my own interfaces and work directly with "*CasinoBalanceManager*" and  "*GameBalanceManager*").
 - ***DepositService*** - the controller works with "*DepositService*" via "*IDepositService*" interface. Created to call the "*IncreaseBalance*" method on the "*CasinoBalanceManager*" service and to call the "*DecreaseBalance*" method on the "*GameBalanceManager*". Because two interfaces were not implemented in "*BalanceManager.DLL*", I decided not to use "*IBalanceManager*" and create my own interfaces to work directly with "*CasinoBalanceManager*" and "*GameBalanceManager*".
 - ***WithdrawService*** - like "*DepositService*" , communicate with the controller occurs through the "*IWithdrawService*" interface. "*WithdrawService*" Created in the same way that "*DepositService*" was created, but the only difference is, the "*GameBalanceManager*" service will call the "*IncreaseBalance*" method, while the "*CasinoBalanceManager*" service will call the "*DecreaseBalance*" method.
<br><br/>
 
 
****Services**** - the "*Common*" folder contains the "*Model*" and "*interface*" folders:
  - ***Interfaces*** - Has an "*IReposnce<T>*" Generic of type Response interface. This folder also contains "*IGetBalanceService*", "*IDepositService*", "*IWithdrawService interfaces*".
  - ***Models*** - has one abstract class with properties (Amount
  and TransactionId) . The "*DepositBalanceChangeModel*" and "*WithdrawBalanceChangeModel*" are inherited from this abstract class, which are created for "*DepositService*" and "*WithdrawService*".
  Also, I created a "*ResponseViewModel*", which I use to create a Custom Response.

<br><br/>
****Shared**** -  there are two divisions of the "*Extensions*" and "*Handlers*" folders.

  - ***Extentions*** - contains the "*EnumExtention*" class, the method of which takes an *Enum* as a parameter. Takes a *Description* and returns it in *string* format. 
 - ***Handlers*** - contains the "*ConfigHandler*" class, the method of which is designed to search the *Enum* passed in the parameter in "*appconfig*" and return its *Value* in *string* format. An "*IsNotSuccess*" *Handler* has also been created, with which you can check the *Enum* for the status of "*Success*". The method is *static* and therefore you can call this method from any other class in the project. Similarly, I created an "*IsNull*" handler to test objects for *NULL*.
<br><br/>

##### "*AutoMapper*" and "*DataBase*"  were not used in the project because the project does not require it.


# About Folder: "tests" 

####  MSUnitTests

The ***tests*** folder contains ***MSUnitTests*** Layers such as "*BalanceControl.Application.Tests*" and "*BalanceControl.Shared.Tests*":

 - ***BalanceControl.Application.Tests*** - The project contains "*ServiceTests*" , which includes a "*DepositServiceTest*" with four active tests that test the functionality of "*Deposit*" and "*Exception Error*". "*GetBalanceServiceTest*" contains two active tests that check the balance. "*WithdrawServiceTest*" contains 4 active tests that check the validity of the "*Withdraw*" function and "*Exception Error*".
 - ***BalanceControl.Shared.Tests*** - Contains two folders "*HandlerTests*" and "*Helper*" . The first one has a "*DescriptionHandlerTest*" class that includes a method to take and test the *Enum* Description. The second class, "*IsNotSuccessHandlerTest*", contains a method that takes an "*ErrorCode*" parameter and checks its status for *Success*. as well the class "*IsNullHandlerTest*" whose method checks objects for equality with *Null*.
 Also, this project has a Helper folder, which contains the *Enum* class "*DescriptionErrorCodeTest*" - the "*ErrorCode*" and its *Description*.



# About Me
####  LinkedIn : https://www.linkedin.com/in/levan-amashukeli/

####  Facebook : https://www.facebook.com/levan.amashukeli.3
