import { useEffect } from 'react'
import ProductList from './ProductList'
import LoadingComponent from '../../app/layout/LoadingComponent'
import { useAppDispatch, useAppSelector } from '../../app/store/configureStore'
import { fetchFilters, fetchProductsAsync, prodoctSelectors, setPageNumber, setProductParams } from './catalogSlice'
import { Grid, Paper } from '@mui/material'
import ProductSearch from './ProductSearch'
import RadioButtonGroup from '../../app/components/RadioButtonGroup'
import CheckboxButtons from '../../app/components/CheckboxButtons'
import AddPagination from '../../app/components/AddPagination'

const sortOptions = [
  {values: 'name', label: 'Alphabetical'},
  {values: 'priceDesc', label: 'Price - High to low'},
  {values: 'price', label: 'Price - Low to high'},
]

export default function Catalog() {
  const products = useAppSelector(prodoctSelectors.selectAll)
  const {productsLoaded, filtersLoaded, brands, types, productParams, metaData} = useAppSelector(state => state.catalog)
  const dispatch = useAppDispatch()

  useEffect(() => {
    if (!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded, dispatch])

  useEffect(() => {
    if (!filtersLoaded) dispatch(fetchFilters());
  }, [dispatch, filtersLoaded])

   if (!filtersLoaded) return <LoadingComponent message='Loading products...' />

  return (
    <Grid container columnSpacing={4}>
      <Grid item xs={3}>
        <Paper sx={{mb: 2}}>
          <ProductSearch />
        </Paper>
        <Paper sx={{mb: 2, p: 2}}>
          <RadioButtonGroup 
            selectedValue={productParams.orderBy}
            options={sortOptions}
            onChange={(e) => dispatch(setProductParams({orderBy: e.target.value}))}
          />
        </Paper>

        <Paper sx={{mb: 2, p: 2}}>
            <CheckboxButtons
                items={brands}
                checked={productParams.brands}
                onChange={(items: string[]) => dispatch(setProductParams({brands: items}))}
            />
        </Paper>

        <Paper sx={{mb: 2, p: 2}}>
        <CheckboxButtons
                items={types}
                checked={productParams.types}
                onChange={(items: string[]) => dispatch(setProductParams({types: items}))}
            />
        </Paper>
        
      </Grid>
      <Grid item xs={9}>
      <ProductList products={products} />
      </Grid>
      <Grid item xs={3} />
      <Grid item xs={9} sx={{mb:2}}>
        {metaData && 
        <AddPagination 
          metaData={metaData}
          onPageChange={(page: number) => dispatch(setPageNumber({pageNumber: page}))}
        />}
      </Grid>
    </Grid>
  )
}
