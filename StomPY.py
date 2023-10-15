import os
import datetime
import argparse

def stompy(file_path, new_timestamp):
    if os.path.exists(file_path):
        timestamp = datetime.datetime.strptime(new_timestamp, "%m/%d/%Y").timestamp()
        os.utime(file_path, (timestamp, timestamp))
        print(f"Timestamp of {file_path} modified to {new_timestamp}")
    else:
        print(f"File {file_path} not found.")

def process_directory(directory, new_timestamp):
    for root, dirs, files in os.walk(directory):
        for name in files:
            stompy(os.path.join(root, name), new_timestamp)

parser = argparse.ArgumentParser(description='Modify file timestamps.')
parser.add_argument('path', help='Path to the file or directory')
parser.add_argument('timestamp', help='New timestamp (MM/DD/YYYY)')
parser.add_argument('-r', '--recursive', action='store_true', help='Apply recursively for directories')

args = parser.parse_args()

if args.recursive and os.path.isdir(args.path):
    process_directory(args.path, args.timestamp)
else:
    stompy(args.path, args.timestamp)
