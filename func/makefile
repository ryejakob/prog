out.txt : main.exe 
	mono main.exe > out.txt

main.exe : main.cs quado8.dll
	mcs -reference:quado8.dll main.cs

quado8.dll : quado8.cs
	mcs -target:library -out:quado8.dll quado8.cs

clean:
	rm -f out.txt main.exe
