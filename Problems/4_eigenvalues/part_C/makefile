all: outC.txt plot_time.svg plot_rotations.svg

plot_rotations.svg: plot_rotations.gpi rotation_cyc.txt rotation_clas.txt
	gnuplot $<

plot_time.svg: plot_time.gpi time_cyc.txt time_clas.txt
	gnuplot $<

time_cyc.txt: main_cyc.exe
	for N in `seq 50 20 150`; do \
	echo "N=$$N";\
	\time -ao time_cyc.txt -f "$$N %U" mono main_cyc.exe $$N>> rotation_cyc.txt ; \
	done

main_cyc.exe : main_cyc.cs jac_dia.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main_cyc.cs

time_clas.txt: main_clas.exe
	for N in `seq 50 20 150`; do \
	echo "N=$$N";\
	\time -ao time_clas.txt -f "$$N %U" mono main_clas.exe $$N>> rotation_clas.txt; \
	done

main_clas.exe : main_clas.cs jac_clas.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_clas.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main_clas.cs

outC.txt : main.exe 
	mono main.exe > outC.txt

main.exe : main.cs jac_clas.dll jac_dia.dll matrix.dll vector.dll RandMatrix.dll 
	mcs -reference:jac_dia.dll -reference:jac_clas.dll -reference:matrix.dll -reference:vector.dll -reference:RandMatrix.dll main.cs

jac_clas.dll: jac_clas.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

jac_dia.dll: jac_dia.cs matrix.dll vector.dll
	mcs -reference:matrix.dll -reference:vector.dll -target:library -out:$@ $<

RandMatrix.dll: RandMatrix.cs matrix.dll
	mcs -reference:matrix.dll -target:library -out:$@ $<

matrix.dll: matrix.cs vector.dll
	mcs -reference:vector.dll -target:library -out:$@ $<

vector.dll: vector.cs
	mcs -target:library -out:$@ $<

clean: ; $(RM) *.dll *.exe *.txt *.svg 
