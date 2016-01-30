// Implementation file for parser generated by fsyacc
module AlvisParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "AlvisParser.fsp"
   
open AlvisSpec  

# 10 "AlvisParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | AGENT
  | EQ
  | LT
  | LE
  | GT
  | GE
  | NE
  | BRACESOPEN
  | BRACESCLOSE
  | PARENTHESEOPEN
  | PARENTHESECLOSE
  | COMMA
  | DOUBLECOLON
  | SEMICOLON
  | COMMENT
  | EOF
  | PROC
  | NULL
  | LOOP
  | EXIT
  | SELECT
  | IF
  | ELSE
  | PORT
  | IN
  | OUT
  | BOOL of (bool)
  | FLOAT of (float)
  | INT of (int)
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_AGENT
    | TOKEN_EQ
    | TOKEN_LT
    | TOKEN_LE
    | TOKEN_GT
    | TOKEN_GE
    | TOKEN_NE
    | TOKEN_BRACESOPEN
    | TOKEN_BRACESCLOSE
    | TOKEN_PARENTHESEOPEN
    | TOKEN_PARENTHESECLOSE
    | TOKEN_COMMA
    | TOKEN_DOUBLECOLON
    | TOKEN_SEMICOLON
    | TOKEN_COMMENT
    | TOKEN_EOF
    | TOKEN_PROC
    | TOKEN_NULL
    | TOKEN_LOOP
    | TOKEN_EXIT
    | TOKEN_SELECT
    | TOKEN_IF
    | TOKEN_ELSE
    | TOKEN_PORT
    | TOKEN_IN
    | TOKEN_OUT
    | TOKEN_BOOL
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_alvisStatements
    | NONTERM_alvisStatement
    | NONTERM_agentBody
    | NONTERM_conditionClause
    | NONTERM_conditionIfElseClause
    | NONTERM_conditionIfClause
    | NONTERM_guardClause
    | NONTERM_conditionBody
    | NONTERM_loopClause
    | NONTERM_loopBody
    | NONTERM_valueList
    | NONTERM_valueClause
    | NONTERM_valueType
    | NONTERM_value
    | NONTERM_op
    | NONTERM_agentList
    | NONTERM_nextLine
    | NONTERM_portList
    | NONTERM_portClause

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | AGENT  -> 0 
  | EQ  -> 1 
  | LT  -> 2 
  | LE  -> 3 
  | GT  -> 4 
  | GE  -> 5 
  | NE  -> 6 
  | BRACESOPEN  -> 7 
  | BRACESCLOSE  -> 8 
  | PARENTHESEOPEN  -> 9 
  | PARENTHESECLOSE  -> 10 
  | COMMA  -> 11 
  | DOUBLECOLON  -> 12 
  | SEMICOLON  -> 13 
  | COMMENT  -> 14 
  | EOF  -> 15 
  | PROC  -> 16 
  | NULL  -> 17 
  | LOOP  -> 18 
  | EXIT  -> 19 
  | SELECT  -> 20 
  | IF  -> 21 
  | ELSE  -> 22 
  | PORT  -> 23 
  | IN  -> 24 
  | OUT  -> 25 
  | BOOL _ -> 26 
  | FLOAT _ -> 27 
  | INT _ -> 28 
  | ID _ -> 29 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_AGENT 
  | 1 -> TOKEN_EQ 
  | 2 -> TOKEN_LT 
  | 3 -> TOKEN_LE 
  | 4 -> TOKEN_GT 
  | 5 -> TOKEN_GE 
  | 6 -> TOKEN_NE 
  | 7 -> TOKEN_BRACESOPEN 
  | 8 -> TOKEN_BRACESCLOSE 
  | 9 -> TOKEN_PARENTHESEOPEN 
  | 10 -> TOKEN_PARENTHESECLOSE 
  | 11 -> TOKEN_COMMA 
  | 12 -> TOKEN_DOUBLECOLON 
  | 13 -> TOKEN_SEMICOLON 
  | 14 -> TOKEN_COMMENT 
  | 15 -> TOKEN_EOF 
  | 16 -> TOKEN_PROC 
  | 17 -> TOKEN_NULL 
  | 18 -> TOKEN_LOOP 
  | 19 -> TOKEN_EXIT 
  | 20 -> TOKEN_SELECT 
  | 21 -> TOKEN_IF 
  | 22 -> TOKEN_ELSE 
  | 23 -> TOKEN_PORT 
  | 24 -> TOKEN_IN 
  | 25 -> TOKEN_OUT 
  | 26 -> TOKEN_BOOL 
  | 27 -> TOKEN_FLOAT 
  | 28 -> TOKEN_INT 
  | 29 -> TOKEN_ID 
  | 32 -> TOKEN_end_of_input
  | 30 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_alvisStatements 
    | 3 -> NONTERM_alvisStatements 
    | 4 -> NONTERM_alvisStatement 
    | 5 -> NONTERM_agentBody 
    | 6 -> NONTERM_agentBody 
    | 7 -> NONTERM_conditionClause 
    | 8 -> NONTERM_conditionClause 
    | 9 -> NONTERM_conditionClause 
    | 10 -> NONTERM_conditionIfElseClause 
    | 11 -> NONTERM_conditionIfClause 
    | 12 -> NONTERM_conditionIfClause 
    | 13 -> NONTERM_guardClause 
    | 14 -> NONTERM_guardClause 
    | 15 -> NONTERM_conditionBody 
    | 16 -> NONTERM_loopClause 
    | 17 -> NONTERM_loopClause 
    | 18 -> NONTERM_loopClause 
    | 19 -> NONTERM_loopClause 
    | 20 -> NONTERM_loopBody 
    | 21 -> NONTERM_loopBody 
    | 22 -> NONTERM_loopBody 
    | 23 -> NONTERM_valueList 
    | 24 -> NONTERM_valueList 
    | 25 -> NONTERM_valueList 
    | 26 -> NONTERM_valueClause 
    | 27 -> NONTERM_valueType 
    | 28 -> NONTERM_value 
    | 29 -> NONTERM_value 
    | 30 -> NONTERM_value 
    | 31 -> NONTERM_value 
    | 32 -> NONTERM_op 
    | 33 -> NONTERM_op 
    | 34 -> NONTERM_op 
    | 35 -> NONTERM_op 
    | 36 -> NONTERM_op 
    | 37 -> NONTERM_op 
    | 38 -> NONTERM_agentList 
    | 39 -> NONTERM_agentList 
    | 40 -> NONTERM_nextLine 
    | 41 -> NONTERM_nextLine 
    | 42 -> NONTERM_nextLine 
    | 43 -> NONTERM_portList 
    | 44 -> NONTERM_portList 
    | 45 -> NONTERM_portList 
    | 46 -> NONTERM_portClause 
    | 47 -> NONTERM_portClause 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 32 
let _fsyacc_tagOfErrorTerminal = 30

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | AGENT  -> "AGENT" 
  | EQ  -> "EQ" 
  | LT  -> "LT" 
  | LE  -> "LE" 
  | GT  -> "GT" 
  | GE  -> "GE" 
  | NE  -> "NE" 
  | BRACESOPEN  -> "BRACESOPEN" 
  | BRACESCLOSE  -> "BRACESCLOSE" 
  | PARENTHESEOPEN  -> "PARENTHESEOPEN" 
  | PARENTHESECLOSE  -> "PARENTHESECLOSE" 
  | COMMA  -> "COMMA" 
  | DOUBLECOLON  -> "DOUBLECOLON" 
  | SEMICOLON  -> "SEMICOLON" 
  | COMMENT  -> "COMMENT" 
  | EOF  -> "EOF" 
  | PROC  -> "PROC" 
  | NULL  -> "NULL" 
  | LOOP  -> "LOOP" 
  | EXIT  -> "EXIT" 
  | SELECT  -> "SELECT" 
  | IF  -> "IF" 
  | ELSE  -> "ELSE" 
  | PORT  -> "PORT" 
  | IN  -> "IN" 
  | OUT  -> "OUT" 
  | BOOL _ -> "BOOL" 
  | FLOAT _ -> "FLOAT" 
  | INT _ -> "INT" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | AGENT  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | BRACESOPEN  -> (null : System.Object) 
  | BRACESCLOSE  -> (null : System.Object) 
  | PARENTHESEOPEN  -> (null : System.Object) 
  | PARENTHESECLOSE  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | DOUBLECOLON  -> (null : System.Object) 
  | SEMICOLON  -> (null : System.Object) 
  | COMMENT  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | PROC  -> (null : System.Object) 
  | NULL  -> (null : System.Object) 
  | LOOP  -> (null : System.Object) 
  | EXIT  -> (null : System.Object) 
  | SELECT  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | PORT  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | OUT  -> (null : System.Object) 
  | BOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | FLOAT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 2us; 65535us; 0us; 2us; 4us; 5us; 2us; 65535us; 0us; 4us; 4us; 4us; 1us; 65535us; 8us; 9us; 3us; 65535us; 13us; 14us; 16us; 17us; 34us; 35us; 3us; 65535us; 13us; 16us; 16us; 16us; 34us; 16us; 3us; 65535us; 13us; 18us; 16us; 18us; 34us; 18us; 1us; 65535us; 20us; 21us; 2us; 65535us; 23us; 24us; 27us; 28us; 2us; 65535us; 12us; 13us; 33us; 34us; 1us; 65535us; 37us; 39us; 1us; 65535us; 8us; 11us; 2us; 65535us; 8us; 44us; 45us; 46us; 1us; 65535us; 48us; 49us; 3us; 65535us; 20us; 30us; 31us; 32us; 51us; 52us; 1us; 65535us; 30us; 31us; 1us; 65535us; 6us; 7us; 4us; 65535us; 11us; 45us; 41us; 42us; 68us; 69us; 70us; 71us; 4us; 65535us; 11us; 12us; 23us; 33us; 27us; 33us; 37us; 43us; 7us; 65535us; 11us; 68us; 12us; 70us; 23us; 68us; 27us; 68us; 33us; 70us; 37us; 68us; 43us; 70us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 9us; 11us; 15us; 19us; 23us; 25us; 28us; 31us; 33us; 35us; 38us; 40us; 44us; 46us; 48us; 53us; 58us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 1us; 2us; 2us; 3us; 1us; 3us; 1us; 4us; 2us; 4us; 39us; 1us; 4us; 1us; 4us; 1us; 4us; 2us; 5us; 25us; 2us; 5us; 45us; 1us; 5us; 1us; 5us; 1us; 6us; 2us; 8us; 9us; 1us; 9us; 1us; 10us; 2us; 11us; 12us; 2us; 11us; 12us; 2us; 11us; 12us; 2us; 11us; 12us; 2us; 11us; 12us; 2us; 11us; 12us; 2us; 11us; 12us; 1us; 12us; 1us; 12us; 1us; 12us; 1us; 12us; 1us; 14us; 1us; 14us; 1us; 14us; 2us; 15us; 45us; 1us; 15us; 1us; 15us; 3us; 17us; 18us; 19us; 2us; 18us; 19us; 1us; 18us; 1us; 19us; 1us; 19us; 1us; 21us; 1us; 21us; 2us; 22us; 45us; 1us; 24us; 1us; 25us; 1us; 25us; 1us; 26us; 1us; 26us; 1us; 26us; 1us; 27us; 1us; 27us; 1us; 27us; 1us; 28us; 1us; 29us; 1us; 30us; 1us; 31us; 1us; 32us; 1us; 33us; 1us; 34us; 1us; 35us; 1us; 36us; 1us; 37us; 1us; 38us; 1us; 39us; 1us; 39us; 2us; 41us; 42us; 1us; 42us; 1us; 44us; 1us; 44us; 1us; 45us; 1us; 45us; 1us; 46us; 1us; 46us; 1us; 47us; 1us; 47us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 13us; 15us; 18us; 20us; 22us; 24us; 27us; 30us; 32us; 34us; 36us; 39us; 41us; 43us; 46us; 49us; 52us; 55us; 58us; 61us; 64us; 66us; 68us; 70us; 72us; 74us; 76us; 78us; 81us; 83us; 85us; 89us; 92us; 94us; 96us; 98us; 100us; 102us; 105us; 107us; 109us; 111us; 113us; 115us; 117us; 119us; 121us; 123us; 125us; 127us; 129us; 131us; 133us; 135us; 137us; 139us; 141us; 143us; 145us; 147us; 149us; 152us; 154us; 156us; 158us; 160us; 162us; 164us; 166us; 168us; |]
let _fsyacc_action_rows = 76
let _fsyacc_actionTableElements = [|1us; 32768us; 0us; 6us; 0us; 49152us; 1us; 32768us; 15us; 3us; 0us; 16385us; 1us; 16386us; 0us; 6us; 0us; 16387us; 1us; 32768us; 29us; 63us; 2us; 32768us; 7us; 8us; 11us; 64us; 2us; 16407us; 17us; 15us; 29us; 47us; 1us; 32768us; 8us; 10us; 0us; 16388us; 6us; 16424us; 8us; 16427us; 13us; 66us; 18us; 16427us; 21us; 16427us; 24us; 72us; 25us; 74us; 3us; 16400us; 18us; 36us; 24us; 72us; 25us; 74us; 1us; 16391us; 21us; 19us; 0us; 16389us; 0us; 16390us; 1us; 16391us; 21us; 19us; 0us; 16393us; 0us; 16394us; 1us; 32768us; 9us; 20us; 4us; 16397us; 26us; 56us; 27us; 54us; 28us; 53us; 29us; 55us; 1us; 32768us; 10us; 22us; 1us; 32768us; 7us; 23us; 2us; 16427us; 24us; 72us; 25us; 74us; 1us; 32768us; 8us; 25us; 1us; 16395us; 22us; 26us; 1us; 32768us; 7us; 27us; 2us; 16427us; 24us; 72us; 25us; 74us; 1us; 32768us; 8us; 29us; 0us; 16396us; 6us; 32768us; 1us; 57us; 2us; 58us; 3us; 59us; 4us; 60us; 5us; 61us; 6us; 62us; 4us; 32768us; 26us; 56us; 27us; 54us; 28us; 53us; 29us; 55us; 0us; 16398us; 3us; 16400us; 18us; 36us; 24us; 72us; 25us; 74us; 1us; 16391us; 21us; 19us; 0us; 16399us; 1us; 16401us; 7us; 37us; 4us; 16404us; 8us; 38us; 19us; 41us; 24us; 72us; 25us; 74us; 0us; 16402us; 1us; 32768us; 8us; 40us; 0us; 16403us; 1us; 16424us; 13us; 66us; 0us; 16405us; 2us; 16406us; 24us; 72us; 25us; 74us; 0us; 16408us; 1us; 32768us; 29us; 47us; 0us; 16409us; 1us; 32768us; 12us; 48us; 1us; 32768us; 29us; 50us; 0us; 16410us; 1us; 32768us; 1us; 51us; 4us; 32768us; 26us; 56us; 27us; 54us; 28us; 53us; 29us; 55us; 0us; 16411us; 0us; 16412us; 0us; 16413us; 0us; 16414us; 0us; 16415us; 0us; 16416us; 0us; 16417us; 0us; 16418us; 0us; 16419us; 0us; 16420us; 0us; 16421us; 0us; 16422us; 1us; 32768us; 29us; 65us; 0us; 16423us; 1us; 16425us; 14us; 67us; 0us; 16426us; 1us; 16424us; 13us; 66us; 0us; 16428us; 1us; 16424us; 13us; 66us; 0us; 16429us; 1us; 32768us; 29us; 73us; 0us; 16430us; 1us; 32768us; 29us; 75us; 0us; 16431us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 2us; 3us; 5us; 6us; 8us; 9us; 11us; 14us; 17us; 19us; 20us; 27us; 31us; 33us; 34us; 35us; 37us; 38us; 39us; 41us; 46us; 48us; 50us; 53us; 55us; 57us; 59us; 62us; 64us; 65us; 72us; 77us; 78us; 82us; 84us; 85us; 87us; 92us; 93us; 95us; 96us; 98us; 99us; 102us; 103us; 105us; 106us; 108us; 110us; 111us; 113us; 118us; 119us; 120us; 121us; 122us; 123us; 124us; 125us; 126us; 127us; 128us; 129us; 130us; 132us; 133us; 135us; 136us; 138us; 139us; 141us; 142us; 144us; 145us; 147us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 2us; 5us; 4us; 1us; 0us; 1us; 2us; 1us; 7us; 11us; 0us; 3us; 3us; 0us; 1us; 3us; 4us; 0us; 2us; 1us; 0us; 1us; 3us; 3us; 3us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 1us; 3us; 0us; 1us; 2us; 0us; 2us; 3us; 2us; 2us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 3us; 4us; 4us; 5us; 5us; 5us; 6us; 7us; 7us; 8us; 8us; 9us; 10us; 10us; 10us; 10us; 11us; 11us; 11us; 12us; 12us; 12us; 13us; 14us; 15us; 15us; 15us; 15us; 16us; 16us; 16us; 16us; 16us; 16us; 17us; 17us; 18us; 18us; 18us; 19us; 19us; 19us; 20us; 20us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 16387us; 65535us; 65535us; 65535us; 65535us; 16388us; 65535us; 65535us; 65535us; 16389us; 16390us; 65535us; 16393us; 16394us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16396us; 65535us; 65535us; 16398us; 65535us; 65535us; 16399us; 65535us; 65535us; 16402us; 65535us; 16403us; 65535us; 16405us; 65535us; 16408us; 65535us; 16409us; 65535us; 65535us; 16410us; 65535us; 65535us; 16411us; 16412us; 16413us; 16414us; 16415us; 16416us; 16417us; 16418us; 16419us; 16420us; 16421us; 16422us; 65535us; 16423us; 65535us; 16426us; 65535us; 16428us; 65535us; 16429us; 65535us; 16430us; 65535us; 16431us; |]
let _fsyacc_reductions ()  =    [| 
# 306 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : AlvisSpec.Agents)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 315 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'alvisStatements)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "AlvisParser.fsp"
                                                  _1
                   )
# 27 "AlvisParser.fsp"
                 : AlvisSpec.Agents));
# 326 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'alvisStatement)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 30 "AlvisParser.fsp"
                                           [_1]
                   )
# 30 "AlvisParser.fsp"
                 : 'alvisStatements));
# 337 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'alvisStatement)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'alvisStatements)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "AlvisParser.fsp"
                                                           _1 :: _2
                   )
# 31 "AlvisParser.fsp"
                 : 'alvisStatements));
# 349 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'agentList)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'agentBody)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "AlvisParser.fsp"
                                                                              {AgentList =  _2; AgentBody = _4}
                   )
# 34 "AlvisParser.fsp"
                 : 'alvisStatement));
# 361 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'valueList)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'portList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'loopClause)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "AlvisParser.fsp"
                                                                                      {Null = false; Values = _1; Ports = _2;  Looping = _3; Condition = _4}
                   )
# 38 "AlvisParser.fsp"
                 : 'agentBody));
# 375 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "AlvisParser.fsp"
                                                                                       {Null = true;  Values = []; Ports = [];  Looping = None; Condition  = []}
                   )
# 39 "AlvisParser.fsp"
                 : 'agentBody));
# 385 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "AlvisParser.fsp"
                            []
                   )
# 44 "AlvisParser.fsp"
                 : 'conditionClause));
# 395 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionIfElseClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "AlvisParser.fsp"
                                                  [_1]
                   )
# 45 "AlvisParser.fsp"
                 : 'conditionClause));
# 406 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionIfElseClause)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "AlvisParser.fsp"
                                                                     _1 :: _2 
                   )
# 46 "AlvisParser.fsp"
                 : 'conditionClause));
# 418 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionIfClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "AlvisParser.fsp"
                                              _1
                   )
# 50 "AlvisParser.fsp"
                 : 'conditionIfElseClause));
# 429 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'guardClause)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionBody)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "AlvisParser.fsp"
                                                                                                                 {Guard=_3; ConditionBody=_6; ElseConditionBody=None}
                   )
# 53 "AlvisParser.fsp"
                 : 'conditionIfClause));
# 441 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'guardClause)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionBody)) in
            let _10 = (let data = parseState.GetInput(10) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionBody)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "AlvisParser.fsp"
                                                                                                                                                         {Guard=_3; ConditionBody=_6; ElseConditionBody=Some(_10)}
                   )
# 54 "AlvisParser.fsp"
                 : 'conditionIfClause));
# 454 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 57 "AlvisParser.fsp"
                            Const(true)
                   )
# 57 "AlvisParser.fsp"
                 : 'guardClause));
# 464 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'op)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "AlvisParser.fsp"
                                            Cond(_1,_2,_3)
                   )
# 58 "AlvisParser.fsp"
                 : 'guardClause));
# 477 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'portList)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'loopClause)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'conditionClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "AlvisParser.fsp"
                                                                             { Ports = _1;  Looping = _2; Condition = _3}
                   )
# 61 "AlvisParser.fsp"
                 : 'conditionBody));
# 490 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "AlvisParser.fsp"
                            None
                   )
# 65 "AlvisParser.fsp"
                 : 'loopClause));
# 500 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "AlvisParser.fsp"
                                 None
                   )
# 66 "AlvisParser.fsp"
                 : 'loopClause));
# 510 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "AlvisParser.fsp"
                                                        None
                   )
# 67 "AlvisParser.fsp"
                 : 'loopClause));
# 520 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'loopBody)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 68 "AlvisParser.fsp"
                                                                 Some(_3)
                   )
# 68 "AlvisParser.fsp"
                 : 'loopClause));
# 531 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "AlvisParser.fsp"
                            {Exit = false; Ports=[] }
                   )
# 71 "AlvisParser.fsp"
                 : 'loopBody));
# 541 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'nextLine)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "AlvisParser.fsp"
                                          {Exit= true; Ports=[]}
                   )
# 72 "AlvisParser.fsp"
                 : 'loopBody));
# 552 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'portList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 73 "AlvisParser.fsp"
                                     {Exit=false; Ports = _1 }
                   )
# 73 "AlvisParser.fsp"
                 : 'loopBody));
# 563 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 76 "AlvisParser.fsp"
                              []
                   )
# 76 "AlvisParser.fsp"
                 : 'valueList));
# 573 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'valueClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 77 "AlvisParser.fsp"
                                        [_1]
                   )
# 77 "AlvisParser.fsp"
                 : 'valueList));
# 584 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'valueList)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'nextLine)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'valueClause)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "AlvisParser.fsp"
                                                             _3::_1 
                   )
# 78 "AlvisParser.fsp"
                 : 'valueList));
# 597 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'valueType)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 82 "AlvisParser.fsp"
                                                      {Name = _1; Value = _3 }
                   )
# 82 "AlvisParser.fsp"
                 : 'valueClause));
# 609 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'value)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 85 "AlvisParser.fsp"
                                                                      _3 
                   )
# 85 "AlvisParser.fsp"
                 : 'valueType));
# 621 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 89 "AlvisParser.fsp"
                                                   Int(_1) 
                   )
# 89 "AlvisParser.fsp"
                 : 'value));
# 632 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : float)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 90 "AlvisParser.fsp"
                                                   Float(_1) 
                   )
# 90 "AlvisParser.fsp"
                 : 'value));
# 643 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 91 "AlvisParser.fsp"
                                                   String(_1) 
                   )
# 91 "AlvisParser.fsp"
                 : 'value));
# 654 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 92 "AlvisParser.fsp"
                                       Bool(_1)
                   )
# 92 "AlvisParser.fsp"
                 : 'value));
# 665 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                              Eq 
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 675 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                                          Lt 
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 685 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                                                      Le 
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 695 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                                                                  Gt 
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 705 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                                                                              Ge 
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 715 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 96 "AlvisParser.fsp"
                                                                                          Ne
                   )
# 96 "AlvisParser.fsp"
                 : 'op));
# 725 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 99 "AlvisParser.fsp"
                                                   [_1]
                   )
# 99 "AlvisParser.fsp"
                 : 'agentList));
# 736 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'agentList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 100 "AlvisParser.fsp"
                                                 _3 :: _1 
                   )
# 100 "AlvisParser.fsp"
                 : 'agentList));
# 748 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 103 "AlvisParser.fsp"
                              
                   )
# 103 "AlvisParser.fsp"
                 : 'nextLine));
# 758 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 104 "AlvisParser.fsp"
                                      
                   )
# 104 "AlvisParser.fsp"
                 : 'nextLine));
# 768 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 105 "AlvisParser.fsp"
                                              
                   )
# 105 "AlvisParser.fsp"
                 : 'nextLine));
# 778 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 108 "AlvisParser.fsp"
                                   [] 
                   )
# 108 "AlvisParser.fsp"
                 : 'portList));
# 788 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'portClause)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'nextLine)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 109 "AlvisParser.fsp"
                                                [_1]
                   )
# 109 "AlvisParser.fsp"
                 : 'portList));
# 800 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'portList)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'portClause)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'nextLine)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 110 "AlvisParser.fsp"
                                                            _2 :: _1
                   )
# 110 "AlvisParser.fsp"
                 : 'portList));
# 813 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 113 "AlvisParser.fsp"
                                       In(_2)
                   )
# 113 "AlvisParser.fsp"
                 : 'portClause));
# 824 "AlvisParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 114 "AlvisParser.fsp"
                                       Out(_2)
                   )
# 114 "AlvisParser.fsp"
                 : 'portClause));
|]
# 836 "AlvisParser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 33;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : AlvisSpec.Agents =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
