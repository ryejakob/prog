out.txt : stdin.exe input.txt
	mono stdin.exe < input.txt > $@ 

stdin.exe: stdin.cs 
	mcs -out:$@ $^


