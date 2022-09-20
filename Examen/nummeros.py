# -*- coding: utf-8 -*-
"""
Created on Sun May 16 22:53:28 2021

@author: danie
"""


_use_abs_location = False

_numbers_file = "nummeros.npy"
# absolute location of numbers binary file for execution on cluster
_numbers_file_abs = "/Users/52722/Desktop/Examen/nummeros.npy"


def get_numbers_file():
    return _numbers_file_abs if _use_abs_location else _numbers_file
