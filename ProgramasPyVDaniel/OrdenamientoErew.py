# -*- coding: utf-8 -*-
"""
Created on Mon May 24 23:37:57 2021

@author:victor daniel archundia
"""
"ORDENAMIENTO EREW"
import os


#Definicion de Funciones
def mergeSort(alist):
    print("DIVIDIENDO ",alist)
    if len(alist)>1:
        mid = len(alist)//2
        lefthalf = alist[:mid]
        righthalf = alist[mid:]

        mergeSort(lefthalf)
        mergeSort(righthalf)

        i=0
        j=0
        k=0
        while i<len(lefthalf) and j<len(righthalf):
            if lefthalf[i]<righthalf[j]:
                alist[k]=lefthalf[i]
                i=i+1
            else:
                alist[k]=righthalf[j]
                j=j+1
            k=k+1

        while i<len(lefthalf):
            alist[k]=lefthalf[i]
            i=i+1
            k=k+1

        while j<len(righthalf):
            alist[k]=righthalf[j]
            j=j+1
            k=k+1
    print("UNIENDO ",alist)

#Programa Principal
alist = []
x=int(input("INGRESE EL NUMERO DE VALORES A INGRESAR"))
i=1
while (i<=x):
    n=int(input("INGRESE UN VALOR"))
    alist.append(n)
    i=i+1
             
   
print ('VALORES ORDENADOS:')
print(alist)

os.system('pause')