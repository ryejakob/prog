all: qspline.svg qderivative.svg qintegral.svg

qintegral.svg: plot_3.gpi out_3.txt
	gnuplot $<

out_3.txt : main_3.exe sin_data.txt
	mono main_3.exe <sin_data.txt > $@ 

main_3.exe: main_3.cs qsline.dll vector.dll
	mcs -reference:qsline.dll -reference:vector.dll -out:main_3.exe main_3.cs

qderivative.svg:plot_2.gpi out_2.txt cos_data.txt
	gnuplot $<

out_2.txt : main_2.exe sin_data.txt
	mono main_2.exe <sin_data.txt > $@ 

main_2.exe: main_2.cs qsline.dll vector.dll
	mcs -reference:qsline.dll -reference:vector.dll -out:main_2.exe main_2.cs

qspline.svg: plot.gpi out.txt sin_data_fine.txt
	gnuplot $<

out.txt : main.exe sin_data.txt
	mono main.exe <sin_data.txt > $@ 

main.exe: main.cs qsline.dll vector.dll
	mcs -reference:qsline.dll -reference:vector.dll -out:main.exe main.cs

qsline.dll: qsline.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<
