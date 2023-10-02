ö
=C:\Users\Cam\source\repos\cgoncalves\Services\BooksService.cs
	namespace		 	
TestApiRest		
 
.		 
Services		 
{

 
public 

class 
BooksService 
: 
IBooksService  -
{ 
private 
readonly 
IBooksRepository )
_bookRepository* 9
;9 :
public 
BooksService 
( 
IBooksRepository ,
bookRepository- ;
); <
{ 	
_bookRepository 
= 
bookRepository ,
;, -
} 	
public 
List 
< 
BookDTO 
> 
GetAllBooks (
(( )
)) *
{ 	
return 
_bookRepository "
." #
GetAllBooks# .
(. /
)/ 0
.0 1
Result1 7
;7 8
} 	
public 
BookDTO 
GetBookById "
(" #
int# &
id' )
)) *
{ 	
return 
_bookRepository "
." #
GetBookById# .
(. /
id/ 1
)1 2
.2 3
Result3 9
;9 :
} 	
public 
BookDTO 

CreateBook !
(! "
BookDTO" )
bookDTO* 1
)1 2
{   	
CustomValidator!! 
<!! 
BookDTO!! #
>!!# $
.!!$ %
DTOValidator!!% 1
(!!1 2
bookDTO!!2 9
)!!9 :
;!!: ;
return"" 
_bookRepository"" "
.""" #

CreateBook""# -
(""- .
bookDTO"". 5
)""5 6
.""6 7
Result""7 =
;""= >
}## 	
public%% 
BookDTO%% 

UpdateBook%% !
(%%! "
BookDTO%%" )
bookDTO%%* 1
)%%1 2
{&& 	
CustomValidator'' 
<'' 
BookDTO'' #
>''# $
.''$ %
DTOValidator''% 1
(''1 2
bookDTO''2 9
)''9 :
;'': ;
return(( 
_bookRepository(( "
.((" #

UpdateBook((# -
(((- .
bookDTO((. 5
)((5 6
.((6 7
Result((7 =
;((= >
})) 	
public++ 
BookDTO++ 

DeleteBook++ !
(++! "
int++" %
id++& (
)++( )
{,, 	
return-- 
_bookRepository-- "
.--" #

DeleteBook--# -
(--- .
id--. 0
)--0 1
.--1 2
Result--2 8
;--8 9
}.. 	
public00 
List00 
<00 
BookDTO00 
>00 #
ReadAndSaveBooksFromCsv00 4
(004 5
	IFormFile005 >
file00? C
)00C D
{11 	
if22 
(22 
file22 
==22 
null22 
||22 
file22  $
.22$ %
Length22% +
==22, .
$num22/ 0
)220 1
{33 
throw44 
new44 
BadRequestException44 -
(44- .
$str44. _
)44_ `
;44` a
}55 
var66 
filePath66 
=66 #
ReadWithTextFieldParser66 2
.662 3
SearchFileAddress663 D
(66D E
file66E I
)66I J
;66J K
var77 
books77 
=77 #
ReadWithTextFieldParser77 /
.77/ 0
ReadCsv770 7
(777 8
filePath778 @
)77@ A
;77A B
_bookRepository88 
.88 
	SaveBooks88 %
(88% &
books88& +
)88+ ,
;88, -
return:: 
books:: 
;:: 
};; 	
}<< 
}== ¡	
IC:\Users\Cam\source\repos\cgoncalves\Services\Interfaces\IBooksService.cs
	namespace 	
TestApiRest
 
. 
Services 
. 

Interfaces )
{ 
public 

	interface 
IBooksService "
{ 
List 
< 
BookDTO 
> 
GetAllBooks !
(! "
)" #
;# $
BookDTO		 
GetBookById		 
(		 
int		 
id		  "
)		" #
;		# $
BookDTO

 

CreateBook

 
(

 
BookDTO

 "
bookDTO

# *
)

* +
;

+ ,
BookDTO 

UpdateBook 
( 
BookDTO "
bookDTO# *
)* +
;+ ,
BookDTO 

DeleteBook 
( 
int 
id !
)! "
;" #
public 
List 
< 
BookDTO 
> #
ReadAndSaveBooksFromCsv 4
(4 5
	IFormFile5 >
file? C
)C D
;D E
} 
} ñ
JC:\Users\Cam\source\repos\cgoncalves\Services\Interfaces\IOrdersService.cs
	namespace 	
TestApiRest
 
. 
Services 
. 

Interfaces )
{ 
public 

	interface 
IOrdersService #
{ 
List 
< 
OrderDTO 
> 
GetAllOrders #
(# $
)$ %
;% &
OrderDTO		 
GetOrderById		 
(		 
int		 !
id		" $
)		$ %
;		% &
OrderDTO

 
CreateOrder

 
(

 
OrderDTO

 %
orderDTO

& .
)

. /
;

/ 0
OrderDTO 
DeleteOrder 
( 
int  
id! #
)# $
;$ %
byte 
[ 
] 
DownloadPDF 
( 
int 
orderId &
)& '
;' (
} 
} Ç
IC:\Users\Cam\source\repos\cgoncalves\Services\Interfaces\IUsersService.cs
	namespace 	
TestApiRest
 
. 
Services 
. 

Interfaces )
{ 
public 

	interface 
IUsersService "
{ 
List 
< 
UserDTO 
> 
GetAllUsers !
(! "
)" #
;# $
UserDTO 
GetUserById 
( 
int 
id  "
)" #
;# $
UserDTO		 

CreateUser		 
(		 
UserDTO		 "
user		# '
)		' (
;		( )
UserDTO

 

UpdateUser

 
(

 
UserDTO

 "
user

# '
)

' (
;

( )
UserDTO 

DeleteUser 
( 
int 
id !
)! "
;" #
} 
} Ë
>C:\Users\Cam\source\repos\cgoncalves\Services\OrdersService.cs
	namespace		 	
TestApiRest		
 
.		 
Services		 
{

 
public 

class 
OrdersService 
:  
IOrdersService! /
{ 
private 
readonly 
IOrdersRepository *
_orderRepository+ ;
;; <
private 
readonly 
ILogger  
<  !
OrdersService! .
>. /
_logger0 7
;7 8
public 
OrdersService 
( 
IOrdersRepository .
orderRepository/ >
,> ?
ILogger@ G
<G H
OrdersServiceH U
>U V
loggerW ]
)] ^
{ 	
_orderRepository 
= 
orderRepository .
;. /
_logger 
= 
logger 
; 
} 	
public 
List 
< 
OrderDTO 
> 
GetAllOrders *
(* +
)+ ,
{ 	
_logger 
. 

LogWarning 
( 
$str <
)< =
;= >
return 
_orderRepository #
.# $
GetAllOrders$ 0
(0 1
)1 2
.2 3
Result3 9
;9 :
} 	
public 
OrderDTO 
GetOrderById $
($ %
int% (
id) +
)+ ,
{ 	
return 
_orderRepository #
.# $
GetOrderById$ 0
(0 1
id1 3
)3 4
.4 5
Result5 ;
;; <
} 	
public   
OrderDTO   
CreateOrder   #
(  # $
OrderDTO  $ ,
pedidoCreateDTO  - <
)  < =
{!! 	
CustomValidator"" 
<"" 
OrderDTO"" $
>""$ %
.""% &
DTOValidator""& 2
(""2 3
pedidoCreateDTO""3 B
)""B C
;""C D
return## 
_orderRepository## #
.### $
CreateOrder##$ /
(##/ 0
pedidoCreateDTO##0 ?
)##? @
.##@ A
Result##A G
;##G H
}$$ 	
public&& 
OrderDTO&& 
DeleteOrder&& #
(&&# $
int&&$ '
id&&( *
)&&* +
{'' 	
return(( 
_orderRepository(( #
.((# $
DeleteOrder(($ /
(((/ 0
id((0 2
)((2 3
.((3 4
Result((4 :
;((: ;
})) 	
public++ 
byte++ 
[++ 
]++ 
DownloadPDF++ !
(++! "
int++" %
orderId++& -
)++- .
{,, 	
return-- 
_orderRepository-- #
.--# $
DownloadPDF--$ /
(--/ 0
orderId--0 7
)--7 8
.--8 9
Result--9 ?
;--? @
}.. 	
}// 
}00 ú
=C:\Users\Cam\source\repos\cgoncalves\Services\UsersService.cs
	namespace 	
TestApiRest
 
. 
Services 
{ 
public 

class 
UsersService 
: 
IUsersService  -
{		 
private

 
readonly

 
IUsersRepository

 )
_userRepository

* 9
;

9 :
public 
UsersService 
( 
IUsersRepository ,
userRepository- ;
); <
{ 	
_userRepository 
= 
userRepository ,
;, -
} 	
public 
List 
< 
UserDTO 
> 
GetAllUsers (
(( )
)) *
{ 	
return 
_userRepository "
." #
GetAllUsers# .
(. /
)/ 0
.0 1
Result1 7
;7 8
} 	
public 
UserDTO 
GetUserById "
(" #
int# &
id' )
)) *
{ 	
return 
_userRepository "
." #
GetUserById# .
(. /
id/ 1
)1 2
.2 3
Result3 9
;9 :
} 	
public 
UserDTO 

CreateUser !
(! "
UserDTO" )

usuarioDTO* 4
)4 5
{ 	
CustomValidator 
< 
UserDTO #
># $
.$ %
DTOValidator% 1
(1 2

usuarioDTO2 <
)< =
;= >
return 
_userRepository "
." #

CreateUser# -
(- .

usuarioDTO. 8
)8 9
.9 :
Result: @
;@ A
} 	
public!! 
UserDTO!! 

UpdateUser!! !
(!!! "
UserDTO!!" )

usuarioDTO!!* 4
)!!4 5
{"" 	
CustomValidator## 
<## 
UserDTO## #
>### $
.##$ %
DTOValidator##% 1
(##1 2

usuarioDTO##2 <
)##< =
;##= >
return$$ 
_userRepository$$ "
.$$" #

UpdateUser$$# -
($$- .

usuarioDTO$$. 8
)$$8 9
.$$9 :
Result$$: @
;$$@ A
}%% 	
public'' 
UserDTO'' 

DeleteUser'' !
(''! "
int''" %
id''& (
)''( )
{(( 	
return)) 
_userRepository)) "
.))" #

DeleteUser))# -
())- .
id)). 0
)))0 1
.))1 2
Result))2 8
;))8 9
}** 	
}++ 
},, 