
from mpi4py import MPI

import numpy as np


def even(number):
    if(number%2 ==0):
        return True
    else:
        return False
    
    
def CompareSplit(a,i,j,comm):
   
    rank = comm.Get_rank()
    tag = 77
    m = len(a)
    tema= np.empty(m,dtype="d")
    tem= np.empty(m,dtype ="d")
    
    
    if rank == i:
        comm.Send(a,dest = j, tag = tag)
        comm.Recv(tema,source = j, tag = tag)
        
        for k in range (0,m):
            tem[k]=a[k]
            
        q=0
        r=0
        
        for k in range(0, m):
            if( tem[q] <= tema[r] ):
                a[k] = tem[q]
                q=q+1
            else:
                
                a[k] =tema[r]
                r=r+1
                
                
    if rank == j:
        comm.Recv(tema, source = i, tag = tag)
        comm.Send(a, dest =i,tag=tag)
        
        for k in range(0,m):
            tem[k] = a[k]
            
        q=m-1
        r=m-1
            
        for k in range(m-1,-1,-1):
            if(tem[q] >= tema[r]):
                a[k] = tem[q]
                q= q - 1
            else:
                a[k] = tema[r]
                r= r -1
            
        
def EvenOddSort(L):
    comm = MPI.COMM_WORLD
    p=comm.Get_size()
    myrank = comm.Get_rank()
    n=len(L)
    m= int(n/p)
        
    a=np.empty(m,dtype = "d")
    if myrank == 0:
        print("Lista Entrada:",algo)
            
    comm.Scatter(L, a, root =0)
    a.sort()
    
    for k in range(0,p):
        if even(myrank):
            if((myrank < p-1)):
                CompareSplit(a.myrank,myrank+1,comm)
            if(myrank>0):
                CompareSplit(a,myrank,myrank-1,comm)
        else:
            CompareSplit(a, myrank-1, myrank, comm)
            if(myrank <p-1):
                CompareSplit(a, myrank, myrank+1, comm)
                
                
    comm.Gather(a, L, root = 0)
    
    if myrank==0:
        print("Lista Ordenada ",L)
        
algo = np.array([1,5,3,11,10,6,7,15],dtype ="float")

EvenOddSort(algo)