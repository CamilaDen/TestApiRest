å
OC:\Users\Cam\source\repos\cgoncalves\TestApiRest\Controllers\BooksController.cs
	namespace

 	
TestApiRest


 
.

 
Controllers

 !
{ 
[ 
ApiController 
] 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
BooksController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IBooksService &
_booksService' 4
;4 5
public 
BooksController 
( 
IBooksService ,
booksService- 9
)9 :
{ 	
_booksService 
= 
booksService (
;( )
} 	
[ 	
HttpGet	 
] 
public   
List   
<   
BookDTO   
>   
GetAllBooks   (
(  ( )
)  ) *
{!! 	
return"" 
_booksService""  
.""  !
GetAllBooks""! ,
("", -
)""- .
;"". /
}## 	
[.. 	
HttpGet..	 
(.. 
$str.. 
).. 
].. 
public// 
BookDTO// 
GetBookById// "
(//" #
int//# &
id//' )
)//) *
{00 	
return11 
_booksService11  
.11  !
GetBookById11! ,
(11, -
id11- /
)11/ 0
;110 1
}22 	
[== 	
HttpPost==	 
]== 
public>> 
BookDTO>> 

CreateBook>> !
(>>! "
BookDTO>>" )
bookDTO>>* 1
)>>1 2
{?? 	
return@@ 
_booksService@@  
.@@  !

CreateBook@@! +
(@@+ ,
bookDTO@@, 3
)@@3 4
;@@4 5
}AA 	
[LL 	
HttpPutLL	 
(LL 
$strLL 
)LL 
]LL 
publicMM 
BookDTOMM 

UpdateBookMM !
(MM! "
[MM" #
FromBodyMM# +
]MM+ ,
BookDTOMM- 4
bookDTOMM5 <
)MM< =
{NN 	
returnOO 
_booksServiceOO  
.OO  !

UpdateBookOO! +
(OO+ ,
bookDTOOO, 3
)OO3 4
;OO4 5
}PP 	
[[[ 	

HttpDelete[[	 
([[ 
$str[[ 
)[[ 
][[  
public\\ 
ActionResult\\ 
<\\ 
BookDTO\\ #
>\\# $

DeleteBook\\% /
(\\/ 0
int\\0 3
id\\4 6
)\\6 7
{]] 	
return^^ 
_booksService^^  
.^^  !

DeleteBook^^! +
(^^+ ,
id^^, .
)^^. /
;^^/ 0
}__ 	
[gg 	
HttpPostgg	 
(gg 
$strgg 
)gg 
]gg 
[hh 	
Consumeshh	 
(hh 
$strhh '
)hh' (
]hh( )
[ii 	 
ProducesResponseTypeii	 
(ii 
StatusCodesii )
.ii) *
Status200OKii* 5
)ii5 6
]ii6 7
[jj 	 
ProducesResponseTypejj	 
(jj 
StatusCodesjj )
.jj) *
Status400BadRequestjj* =
)jj= >
]jj> ?
publickk 
Listkk 
<kk 
BookDTOkk 
>kk 
	UploadCsvkk &
(kk& '
	IFormFilekk' 0
filekk1 5
)kk5 6
{ll 	
returnmm 
_booksServicemm  
.mm  !#
ReadAndSaveBooksFromCsvmm! 8
(mm8 9
filemm9 =
)mm= >
;mm> ?
}nn 	
}pp 
}qq ‘
PC:\Users\Cam\source\repos\cgoncalves\TestApiRest\Controllers\OrdersController.cs
	namespace 	
TestApiRest
 
. 
Controllers !
{		 
[

 
ApiController

 
]

 
[ 
Route 

(
 
$str 
) 
] 
public 

class 
OrdersController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
IOrdersService '
_ordersService( 6
;6 7
public 
OrdersController 
(  
IOrdersService  .
ordersService/ <
)< =
{ 	
_ordersService 
= 
ordersService *
;* +
} 	
[ 	
HttpGet	 
] 
public 
List 
< 
OrderDTO 
> 
GetAllOrders *
(* +
)+ ,
{ 	
return   
_ordersService   !
.  ! "
GetAllOrders  " .
(  . /
)  / 0
;  0 1
}!! 	
[,, 	
HttpGet,,	 
(,, 
$str,, 
),, 
],, 
public-- 
OrderDTO-- 
GetOrderById-- $
(--$ %
int--% (
id--) +
)--+ ,
{.. 	
return// 
_ordersService// !
.//! "
GetOrderById//" .
(//. /
id/// 1
)//1 2
;//2 3
}00 	
[;; 	
HttpPost;;	 
];; 
public<< 
OrderDTO<< 
CreateOrder<< #
(<<# $
OrderDTO<<$ ,
pedidoCreateDTO<<- <
)<<< =
{== 	
return>> 
_ordersService>> !
.>>! "
CreateOrder>>" -
(>>- .
pedidoCreateDTO>>. =
)>>= >
;>>> ?
}?? 	
[JJ 	

HttpDeleteJJ	 
(JJ 
$strJJ 
)JJ 
]JJ 
publicKK 
ActionResultKK 
<KK 
OrderDTOKK $
>KK$ %
DeleteOrderKK& 1
(KK1 2
intKK2 5
idKK6 8
)KK8 9
{LL 	
tryMM 
{NN 
varOO 
orderOO 
=OO 
_ordersServiceOO *
.OO* +
DeleteOrderOO+ 6
(OO6 7
idOO7 9
)OO9 :
;OO: ;
returnPP 
OkPP 
(PP 
orderPP 
)PP  
;PP  !
}QQ 
catchRR 
(RR 
	ExceptionRR 
)RR 
{SS 
throwTT 
newTT 
BadRequestExceptionTT -
(TT- .
$strTT. M
)TTM N
;TTN O
}UU 
}VV 	
[aa 	
HttpPostaa	 
(aa 
$straa 
)aa  
]aa  !
publicbb 
ActionResultbb 
DownloadPDFbb '
(bb' (
intbb( +
orderIdbb, 3
)bb3 4
{cc 	
trydd 
{ee 
varff 
	fileBytesff 
=ff 
_ordersServiceff  .
.ff. /
DownloadPDFff/ :
(ff: ;
orderIdff; B
)ffB C
;ffC D
returngg 
Filegg 
(gg 
	fileBytesgg %
,gg% &
$strgg' 8
,gg8 9
$strgg: E
)ggE F
;ggF G
}hh 
catchii 
(ii 
	Exceptionii 
exii 
)ii  !
{jj 
throwkk 
newkk 
BadRequestExceptionkk -
(kk- .
exkk. 0
.kk0 1
Messagekk1 8
)kk8 9
;kk9 :
}ll 
}mm 	
}nn 
}oo à
PC:\Users\Cam\source\repos\cgoncalves\TestApiRest\Controllers\UsersControllers.cs
	namespace 	
TestApiRest
 
. 
Controllers !
{ 
[ 
ApiController 
] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
UsersControllers

 !
:

" #
ControllerBase

$ 2
{ 
private 
readonly 
IUsersService &
_userService' 3
;3 4
public 
UsersControllers 
(  
IUsersService  -
usersService. :
): ;
{ 	
_userService 
= 
usersService '
;' (
} 	
[ 	
HttpGet	 
] 
public 
List 
< 
UserDTO 
> 
GetAllUsers (
(( )
)) *
{ 	
return 
_userService 
.  
GetAllUsers  +
(+ ,
), -
;- .
} 	
[** 	
HttpGet**	 
(** 
$str** 
)** 
]** 
public++ 
UserDTO++ 
GetUserById++ "
(++" #
int++# &
id++' )
)++) *
{,, 	
return-- 
_userService-- 
.--  
GetUserById--  +
(--+ ,
id--, .
)--. /
;--/ 0
}.. 	
[99 	
HttpPost99	 
]99 
public:: 
ActionResult:: 
<:: 
UserDTO:: #
>::# $

CreateUser::% /
(::/ 0
UserDTO::0 7
userDTO::8 ?
)::? @
{;; 	
return<< 
_userService<< 
.<<  

CreateUser<<  *
(<<* +
userDTO<<+ 2
)<<2 3
;<<3 4
}== 	
[HH 	
HttpPutHH	 
(HH 
$strHH 
)HH 
]HH 
publicII 
UserDTOII 

UpdateUserII !
(II! "
UserDTOII" )
userDTOII* 1
)II1 2
{JJ 	
returnKK 
_userServiceKK  
.KK  !

UpdateUserKK! +
(KK+ ,
userDTOKK, 3
)KK3 4
;KK4 5
}LL 	
[WW 	

HttpDeleteWW	 
(WW 
$strWW 
)WW 
]WW 
publicXX 
ActionResultXX 
<XX 
UserDTOXX #
>XX# $

DeleteUserXX% /
(XX/ 0
intXX0 3
idXX4 6
)XX6 7
{YY 	
returnZZ 
_userServiceZZ 
.ZZ  

DeleteUserZZ  *
(ZZ* +
idZZ+ -
)ZZ- .
;ZZ. /
}[[ 	
}\\ 
}]] ‹
HC:\Users\Cam\source\repos\cgoncalves\TestApiRest\Headers\ApiKeyHeader.cs
	namespace 	
TestApiRest
 
. 
Headers 
{ 
public 

class 
ApiKeyHeader 
: 
IOperationFilter  0
{ 
public 
void 
Apply 
( 
OpenApiOperation *
	operation+ 4
,4 5"
OperationFilterContext6 L
contextM T
)T U
{		 	
if

 
(

 
	operation

 
.

 

Parameters

 $
==

% '
null

( ,
)

, -
	operation 
. 

Parameters $
=% &
new' *
List+ /
</ 0
OpenApiParameter0 @
>@ A
(A B
)B C
;C D
	operation 
. 

Parameters  
.  !
Add! $
($ %
new% (
OpenApiParameter) 9
{ 
Name 
= 
$str 
,  
In 
= 
ParameterLocation &
.& '
Header' -
,- .
Required 
= 
true 
,  
Schema 
= 
new 
OpenApiSchema *
{ 
Type 
= 
$str #
} 
} 
) 
; 
} 	
} 
} “
;C:\Users\Cam\source\repos\cgoncalves\TestApiRest\Program.cs
var 
logger 

= 
NLog 
. 

LogManager 
. 
Setup "
(" #
)# $
.$ %,
 LoadConfigurationFromAppSettings% E
(E F
)F G
.G H!
GetCurrentClassLoggerH ]
(] ^
)^ _
;_ `
logger 
. 
Debug 
( 
$str 
) 
; 
try 
{ 
var 
builder 
= 
WebApplication  
.  !
CreateBuilder! .
(. /
args/ 3
)3 4
;4 5
builder		 
.		 
Logging		 
.		 
ClearProviders		 "
(		" #
)		# $
;		$ %
builder

 
.

 
Host

 
.

 
UseNLog

 
(

 
)

 
;

 
var 
startup 
= 
new 
Startup 
( 
builder %
.% &
Configuration& 3
)3 4
;4 5
startup 
. 
ConfigureServices 
( 
builder %
.% &
Services& .
). /
;/ 0
var 
app 
= 
builder 
. 
Build 
( 
) 
; 
startup 
. 
	Configure 
( 
app 
, 
app 
. 
Environment *
)* +
;+ ,
app 
. 
Run 
( 
) 
; 
} 
catch 
( 
	Exception 
ex 
) 
{ 
logger 

.
 
Error 
( 
ex 
, 
$str F
)F G
;G H
throw 
; 
} 
finally 
{ 
NLog 
. 	

LogManager	 
. 
Shutdown 
( 
) 
; 
} Ñ6
;C:\Users\Cam\source\repos\cgoncalves\TestApiRest\Startup.cs
	namespace 	
TestApiRest
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
.% &
AddJsonOptions& 4
(4 5
x5 6
=>7 9
x: ;
.; <!
JsonSerializerOptions< Q
.Q R
ReferenceHandlerR b
=c d
ReferenceHandlere u
.u v
IgnoreCycles	v ‚
)
‚ ƒ
;
ƒ „
services 
. 
AddDbContext !
<! " 
ApplicationDbContext" 6
>6 7
(7 8
options 
=> 
options "
." #
UseSqlServer# /
(/ 0
Configuration0 =
.= >
GetConnectionString> Q
(Q R
$strR e
)e f
,f g
options 
=> 
options "
." #
MigrationsAssembly# 5
(5 6
$str6 B
)B C
)C D
)D E
;E F
services 
. #
AddEndpointsApiExplorer ,
(, -
)- .
;. /
services 
. 
AddSwaggerGen "
(" #
c# $
=>% '
{ 
var!! 
xmlFile!! 
=!! 
$"!!  
{!!  !
Assembly!!! )
.!!) * 
GetExecutingAssembly!!* >
(!!> ?
)!!? @
.!!@ A
GetName!!A H
(!!H I
)!!I J
.!!J K
Name!!K O
}!!O P
$str!!P T
"!!T U
;!!U V
var"" 
xmlPath"" 
="" 
Path"" "
.""" #
Combine""# *
(""* +

AppContext""+ 5
.""5 6
BaseDirectory""6 C
,""C D
xmlFile""E L
)""L M
;""M N
c## 
.## 
IncludeXmlComments## $
(##$ %
xmlPath##% ,
)##, -
;##- .
c$$ 
.$$ 

SwaggerDoc$$ 
($$ 
$str$$ !
,$$! "
new$$# &
	Microsoft$$' 0
.$$0 1
OpenApi$$1 8
.$$8 9
Models$$9 ?
.$$? @
OpenApiInfo$$@ K
{%% 
Version&& 
=&& 
$str&& "
,&&" #
Title'' 
='' 
$str'' -
,''- .
Description(( 
=((  !
$str((" S
})) 
))) 
;)) 
c** 
.** 
OperationFilter** !
<**! "
ApiKeyHeader**" .
>**. /
(**/ 0
)**0 1
;**1 2
}++ 
)++ 
;++ 
services,, 
.,, 
AddAutoMapper,, "
(,," #
typeof,,# )
(,,) *
Startup,,* 1
),,1 2
),,2 3
;,,3 4
services-- 
.-- 
AddCors-- 
(-- 
options-- $
=>--% '
{.. 
options// 
.// 
	AddPolicy// !
(//! "
$str//" *
,//* +
policy00 
=>00 
{11 
policy22 
.22 
AllowAnyOrigin22 -
(22- .
)22. /
.33 
AllowAnyHeader33 '
(33' (
)33( )
.44 
AllowAnyMethod44 '
(44' (
)44( )
;44) *
}55 
)55 
;55 
}66 
)66 
;66 
services77 
.77 
	AddScoped77 
<77 
IBooksRepository77 /
,77/ 0
BooksRepository771 @
>77@ A
(77A B
)77B C
;77C D
services88 
.88 
	AddScoped88 
<88 
IUsersRepository88 /
,88/ 0
UsersRepository881 @
>88@ A
(88A B
)88B C
;88C D
services99 
.99 
	AddScoped99 
<99 
IOrdersRepository99 0
,990 1
OrdersRepository992 B
>99B C
(99C D
)99D E
;99E F
services;; 
.;; 
	AddScoped;; 
<;; 
IBooksService;; ,
,;;, -
BooksService;;. :
>;;: ;
(;;; <
);;< =
;;;= >
services<< 
.<< 
	AddScoped<< 
<<< 
IUsersService<< ,
,<<, -
UsersService<<. :
><<: ;
(<<; <
)<<< =
;<<= >
services== 
.== 
	AddScoped== 
<== 
IOrdersService== -
,==- .
OrdersService==/ <
>==< =
(=== >
)==> ?
;==? @
}?? 	
public@@ 
void@@ 
	Configure@@ 
(@@ 
IApplicationBuilder@@ 1
app@@2 5
,@@5 6
IWebHostEnvironment@@7 J
env@@K N
)@@N O
{AA 	
ifBB 
(BB 
envBB 
.BB 
IsDevelopmentBB !
(BB! "
)BB" #
)BB# $
{CC 
appDD 
.DD 

UseSwaggerDD 
(DD 
)DD  
;DD  !
appEE 
.EE 
UseSwaggerUIEE  
(EE  !
)EE! "
;EE" #
}FF 
appGG 
.GG 
UseCorsGG 
(GG 
)GG 
;GG 
appHH 
.HH 
UseHttpsRedirectionHH #
(HH# $
)HH$ %
;HH% &
appII 
.II 

UseRoutingII 
(II 
)II 
;II 
appJJ 
.JJ 
UseAuthorizationJJ  
(JJ  !
)JJ! "
;JJ" #
appKK 
.KK 
UseMiddlewareKK 
<KK 
ValidatorMiddlewareKK 1
>KK1 2
(KK2 3
)KK3 4
;KK4 5
appLL 
.LL 
UseEndpointsLL 
(LL 
	endpointsLL &
=>LL' )
{LL* +
	endpointsLL, 5
.LL5 6
MapControllersLL6 D
(LLD E
)LLE F
;LLF G
}LLH I
)LLI J
;LLJ K
}MM 	
}NN 
}OO ‘
LC:\Users\Cam\source\repos\cgoncalves\TestApiRest\Utils\AutoMapperProfiles.cs
	namespace 	
TestApiRest
 
. 
Utils 
{ 
public 

class 
AutoMapperProfiles #
:$ %
Profile& -
{		 
public

 
AutoMapperProfiles

 !
(

! "
)

" #
{ 	
	CreateMap 
< 
UserDTO 
, 
User #
># $
($ %
)% &
;& '
	CreateMap 
< 
User 
, 
UserDTO #
># $
($ %
)% &
;& '
	CreateMap 
< 
Book 
, 
BookDTO "
>" #
(# $
)$ %
;% &
	CreateMap 
< 
BookDTO 
, 
Book "
>" #
(# $
)$ %
;% &
	CreateMap 
< 
Order 
, 
OrderDTO $
>$ %
(% &
)& '
;' (
	CreateMap 
< 
OrderDTO 
, 
Order  %
>% &
(& '
)' (
;( )
	CreateMap 
< 
OrderDetail !
,! "
OrderDetailDTO# 1
>1 2
(2 3
)3 4
;4 5
	CreateMap 
< 
OrderDetailDTO $
,$ %
OrderDetail& 1
>1 2
(2 3
)3 4
;4 5
} 	
} 
} 