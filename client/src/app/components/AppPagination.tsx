import { Box, Typography, Pagination } from "@mui/material";
import { useState } from "react";
import { MetaData } from "../models/paginaton";

interface Props {
    metaData: MetaData;
    onPageChange: (page: number) => void;
}

export default function AppPaginaton({metaData, onPageChange}: Props) {
    const {currentPage, totalCount, totalPages, pageSize} = metaData;
    const [pageNumber, setPageNumber] = useState(currentPage);

    function handlePageChange(page: number) {
      setPageNumber(page);
      onPageChange(page);
    }

    return (
        <Box display='flex' justifyContent='space-between' alignItems='center'>
            <Typography>
              Dispalying {(currentPage-1)*pageSize+1}-
              {currentPage*pageSize > totalCount 
              ? totalCount 
              : currentPage*pageSize} of {totalCount} items
            </Typography>
            <Pagination 
              color='secondary'
              size='large'
              count={totalPages}
              page={currentPage}
              onChange={(e, page) => handlePageChange(page)}
            />
        </Box>
    )
}