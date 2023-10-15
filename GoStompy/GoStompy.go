package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"time"
)

// Flags
var (
	filePathPtr  = flag.String("path", "", "Path to the file or directory.")
	timeStampPtr = flag.String("timestamp", "", "New timestamp in format DD/MM/YYYY.")
	recursivePtr = flag.Bool("recursive", false, "Recursively apply timestamp to files in the directory.")
)

func stompy(filePath string, t time.Time) {
	info, err := os.Stat(filePath)
	if err != nil {
		fmt.Println("Error:", err)
		return
	}

	if !info.IsDir() {
		err = os.Chtimes(filePath, t, t)
		if err != nil {
			fmt.Println("Error changing timestamp:", err)
			return
		}

		fmt.Printf("Timestamp of %s modified to %s\n", filePath, t)
	} else {
		fmt.Println("The given path is a directory, not a file.")
	}
}

func main() {
	flag.Parse()

	if *filePathPtr == "" || *timeStampPtr == "" {
		fmt.Println("Please specify both file path and timestamp.")
		return
	}

	layout := "01/02/2006"
	t, err := time.Parse(layout, *timeStampPtr)
	if err != nil {
		log.Fatalf("Error parsing the provided timestamp: %v", err)
	}

	if *recursivePtr {
		err = filepath.Walk(*filePathPtr, func(path string, info os.FileInfo, err error) error {
			if err != nil {
				return err
			}
			if !info.IsDir() {
				stompy(path, t)
			}
			return nil
		})
		if err != nil {
			log.Fatalf("Error walking the path %v: %v", *filePathPtr, err)
		}
	} else {
		stompy(*filePathPtr, t)
	}
}
