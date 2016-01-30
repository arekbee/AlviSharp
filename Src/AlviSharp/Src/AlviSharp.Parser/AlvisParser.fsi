// Signature file for parser generated by fsyacc
module AlvisParser
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
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_alvisStatements
    | NONTERM_alvisStatement
    | NONTERM_agentBody
    | NONTERM_procList
    | NONTERM_procClause
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
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (AlvisSpec.Agents) 