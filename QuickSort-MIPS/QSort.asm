.data # RAM
eof: .asciiz " \n"
string1: .asciiz "Enter the number of items in the array->"
string2: .asciiz "Enter the number->"

NumItems: .word 0

NumArr1: .space 400 
NumArr2: .space 400 

.text #code

main:
 
 li $v0,4 # print string
 la $a0,string1
 syscall
 
 li $v0,5 # read integer
 syscall
 move $t0,$v0  #$t0 hold the number of items in the array
 move $a0,$t0
 la $a1,NumArr1
 
 jal InputNumbers
 
 addi $t9,$t2,0 #$t9 holds the number of items in array used for printnumbers proc
 
 la $a0,NumArr1
 addi $t0,$t0,-1
 sll $t0,$t0,2
 add $a1,$a0,$t0
 
 jal Quicksort
 
 la $a0,NumArr1 #holds the address of the starting spot in arry
 move $a1, $t9 #holds the number of items in array
 jal PrintNumbers
 
  li $v0, 10 
  syscall  # Quit main
 .end main
 
 Quicksort:
 bge $a0,$a1,breakQSort
 addi $sp,$sp,-12 #put a0 a1,ra on stack
 sw $a0,0($sp)
 sw $a1,4($sp)
 sw $ra,8($sp)
 
 jal partition
 
 lw $a0,0($sp) #restore a0 a1,ra from stack
 lw $a1,4($sp)
 lw $ra,8($sp)
 addi $sp,$sp,12

 addi $sp,$sp,-16
 sw $a0,0($sp) #put a0 a1,ra,v0 on stack
 sw $a1,4($sp)
 sw $ra,8($sp)
 sw $v0,12($sp)
 
 addi $a1, $v0,-4
 jal Quicksort #left
 
 lw $a0,0($sp) #restore a0 a1,ra,v0 from stack
 lw $a1,4($sp)
 lw $ra,8($sp)
 lw $v0,12($sp)
 addi $sp,$sp,16
 
 addi $sp,$sp,-16
 sw $a0,0($sp) #put a0 a1,ra,v0 on stack
 sw $a1,4($sp)
 sw $ra,8($sp)
 sw $v0,12($sp) 
 
 addi $a0, $v0,4 
 jal Quicksort #right
 
 lw $a0,0($sp) #restore a0 a1,ra,v0 from stack
 lw $a1,4($sp)
 lw $ra,8($sp)
 lw $v0,12($sp)
 addi $sp,$sp,16 

 breakQSort:
 jr $ra
 .end Quicksort


partition:

  add $t0,$a0,$a1
  sra $t0,$t0,1
  andi $t1,$t0,3
  beq $t1,$0,swap
  addi $t0,$t0,2
  
  swap:
  lw $t2,0($t0)  # move the pivot value into t2
  lw $t3,0($a0)
  sw $t3,0($t0)
  
  loop1:
  
  	loop2:  #right to left
  	 beq $a0,$a1,endloop1 # found pivot location
  	 lw $t4,0($a1)
  	 ble $t4, $t2,endloop2
  	 addi $a1,$a1,-4  #move one position to the left
  	j loop2
  	endloop2:
  	#move value from right side to left side
  	sw $t4, 0($a0) 
  	addi $a0,$a0,4
  	
  	loop3:  #left to right
  	 beq $a0,$a1,endloop1 # found pivot location
  	 lw $t4,0($a0)
  	 bge $t4, $t2,endloop3
  	 addi $a0,$a0,4  #move one position to the right
  	j loop3
  	endloop3:
  	#move value from right side to left side
  	sw $t4, 0($a1) 
  	addi $a1,$a1,-4
  
  j loop1
  endloop1:
  sw $t2,0($a0)
  move $v0,$a0

 jr $ra
.end partition

 InputNumbers:
  
 li $t1,0
 move $t2,$a0
  
 toploop1:
 beq $t1,$t2,endloop # Fall out of loop
  
 li $v0,4 # print string
 la $a0,string2
 syscall
 
 li $v0,5 # read integer
 syscall
 
 sw $v0,0($a1)
 
 addi $t1,$t1,1
 addi $a1,$a1,4
 j toploop1
 endloop:
  jr $ra
 .end InputNumbers
 
 
 PrintNumbers:
 li $t0,0 #index
 #$a0 is starting address, $a1 is number of items
 printloop1:
	beq $t0,$t9,endprintloop1
	move $t7, $a0 #moves address of $a0 into $t7 i think
	
	lw $t6, 0($a0)#loads value in $a0 into 
	
	li $v0,1
	move $a0,$t6
	syscall
	
	li $v0,4
	la $a0,eof
	syscall
	move $a0,$t7 #moves address back into $a0
	
	addi $t0, $t0, 1
	addi $a0, $a0, 4
	
 	j printloop1
 endprintloop1:
 jr $ra
 .end PrintNumbers
 



