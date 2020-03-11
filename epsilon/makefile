out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs epsi.dll
	mcs -reference:epsi.dll main.cs





cmath.dll : cmath.cs complex.cs 
	mcs -target:library -out:cmath.dll cmath.cs complex.cs

epsi.dll : epsi.cs cmath.dll
	mcs -target:library -out:epsi.dll -reference:cmath.dll epsi.cs

clean:
	rm -f out.txt main.exe
