all: sin_data.txt sin_data_fine.txt cos_data.txt

sin_data_fine.txt: main_sin_f.exe
	mono $< > $@

main_sin_f.exe: main_sin_f.cs 
	mcs main_sin_f.cs

cos_data.txt: main_cos.exe
	mono $< > $@

main_cos.exe: main_cos.cs 
	mcs main_cos.cs

sin_data.txt: main.exe
	mono $< > $@

main.exe: main.cs 
	mcs main.cs


