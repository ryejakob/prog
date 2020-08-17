using static matrix;
using static vector;
using static System.Console;
using static System.Math;

// Implementation of QR decomposition using Givens rotations.
// This only needs to implement the public void decomp(matrix A) method
// not implemented in the abstract parent class qr_abstract.
public class qr_givens : qr_abstract {
	matrix _G;
	public matrix G{get{return _G;}}
	// Constructor simply calling the constructor of the parent class,
	// qr_abstract:
	
	public qr_givens(matrix A) : base(A) {}
	
	// Decomposes matrix A, in this case saving the the upper triangular 
	// matrix R and the sequence of givens rotations in the same matrix
	// G.
	override public void decomp(matrix A) {
		_G = A.copy();
		double theta_pq;
		double c;
		double s;
		double A_pj2;
		double A_qj2;
		// Itterate over the columns first:
		for(int j = 0; j < _G.size2; j++) {
			// Itterate over all rows below the diagonal:
			for(int i = j+1; i < _G.size1; i++) {
				theta_pq = Atan2(_G[i, j], _G[j, j]);
				// Write($"({i}, {j}): theta = Atan2({_G[i, j]}, {_G[j, j]}) =  {theta_pq}\n");
				c = cos(theta_pq);
				s = sin(theta_pq);
				// Recalculate the relevant rows: 
				// Needs to start from j, as the angles theta are saved in
				// the matrix instead of the 0's that are normally there.
				for(int j2 = j; j2 < _G.size2; j2++) {
					A_pj2 = c*_G[j, j2] + s*_G[i, j2];
					A_qj2 = -s*_G[j, j2] + c*_G[i, j2];
					// Write($"-s*{_G[j, j2]} + c*{_G[i, j2]} = {A_qj2}\n");
					_G[j, j2] = A_pj2;
					_G[i, j2] = A_qj2;	
				}	
				_G[i, j] = theta_pq;
				// Write($"theta_({i}, {j}) = {theta_pq}\n");
				// _G.print($"G = ");
				
			}
		}
	}	
	
	override public vector solve(vector b) {
		// Apply all of the Givens rotations specified by the thethas
		// saved in the matrix G to the vector b. Then solve the system
		// by backsubstitution with the upper diagonal part of the matrix.
		vector x = applyQT(b);
		backSubstitution(_G, x);
		return x;
	}
	
	// In place application of the operation Q^(T) using the givens angles
	// stored in _G on the vector x.
	public vector applyQT(vector b) {
		vector x = b.copy();
		double theta;
		double c;
		double s;
		double x_p;
		double x_q;
		// Two loops to itterate over all theta:
		for(int j = 0; j < _G.size2; j++) {
			for(int i = j+1; i < _G.size1; i++) {
				theta = _G[i, j];
				c = cos(theta);
				s = sin(theta);
				
				x_p	= c*x[j] + s*x[i];
				x_q = -s*x[j] + c*x[i];
			
				x[j] = x_p;
				x[i] = x_q;
			}
		}
		return x;
	}
}
