
"""
Created on Mon May 24 22:42:16 2021

@author:victor daniel archundia
"""
"SUMA CREW"

import math
import threading
import os
#Definicion del hilo
def hilo (i,j):
    Array[j] = Array[j] + Array[j - pow(2,i-1)]
    print (Array)


print ('SUMA EN PREFIJO CREW')

Array=[0,5,2,10,1,8,12,7,3]

n=len(Array)
lg=int(math.log(n,2))

#Algoritmo Suma de Crew
for i in range(1,lg-1):
    for j in range((pow(2,i-1)+1),n):
        h = threading.Thread(target=hilo,args=(i,j))
        h.start()
        h.join()

print (Array)
os.system('pause')


